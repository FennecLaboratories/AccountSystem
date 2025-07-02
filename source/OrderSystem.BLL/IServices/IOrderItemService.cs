using OrderSystem.BLL.DTOs;

namespace OrderSystem.BLL.Services;

public interface IOrderItemService
{
	Task<IEnumerable<OrderItemDto>> GetAllAsync();
	Task<OrderItemDto?> GetByOrderAndItemIdAsync(long orderId, long itemId);
	Task AddAsync(OrderItemDto orderItemDto);
	Task UpdateAsync(OrderItemDto orderItemDto);
	Task DeleteAsync(long orderId, long itemId);
}

