using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories.OrderItemRepository;

public interface IOrderItemRepository : IBaseRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    Task<decimal> GetOrderTotalAsync(int orderId);
}