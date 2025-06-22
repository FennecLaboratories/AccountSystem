using OrderSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace OrderSystem.Repository.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersWithDetailsAsync()
    {
        return await _dbSet
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
            .Include(o => o.User)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderWithDetailsByIdAsync(int id)
    {
        return await _dbSet
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
            .Include(o => o.User)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
    {
        return await _dbSet
            .Include(o => o.OrderItems)
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }
}