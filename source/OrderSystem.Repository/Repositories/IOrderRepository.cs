using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersWithDetailsAsync();
    Task<Order?> GetOrderWithDetailsByIdAsync(int id);
    Task<IEnumerable<Order>> GetUserOrdersAsync(int userId);
}