using OrderSystem.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystem.BLL.Services;


public interface IOrderService
{
	Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
	Task<OrderDto?> GetOrderByIdAsync(long id);
	Task AddOrderAsync(OrderDto orderDto);
	Task UpdateOrderAsync(OrderDto orderDto);
	Task DeleteOrderAsync(long id);
}
