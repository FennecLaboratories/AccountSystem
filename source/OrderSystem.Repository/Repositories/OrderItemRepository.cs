using Microsoft.EntityFrameworkCore;
using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories;

public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
    {
        return await _dbSet
            .Include(oi => oi.Item)
            .Where(oi => oi.OrderId == orderId)
            .ToListAsync();
    }

    public async Task<decimal> GetOrderTotalAsync(int orderId)
    {
        return await _dbSet
            .Where(oi => oi.OrderId == orderId)
            .SumAsync(oi => oi.Quantity * oi.PriceAtPurchase);
    }
}