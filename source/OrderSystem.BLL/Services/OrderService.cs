
namespace OrderSystem.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllWithItemsAsync();
        return orders.Select(order => new OrderDto
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            UserId = order.UserId,
            OrderItems = order.OrderItems.Select(oi => new OrderItemDto
            {
                ItemId = oi.ItemId,
                ItemName = oi.Item.Name,
                Quantity = oi.Quantity,
                PriceAtPurchase = oi.PriceAtPurchase
            }).ToList()
        });
    }

    public async Task<OrderDto?> GetOrderByIdAsync(long id)
    {
        var order = await _orderRepository.GetByIdWithItemsAsync(id);
        if (order == null) return null;

        return new OrderDto
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            TotalAmount = order.TotalAmount,
            UserId = order.UserId,
            OrderItems = order.OrderItems.Select(oi => new OrderItemDto
            {
                ItemId = oi.ItemId,
                ItemName = oi.Item.Name,
                Quantity = oi.Quantity,
                PriceAtPurchase = oi.PriceAtPurchase
            }).ToList()
        };
    }

    public async Task AddOrderAsync(OrderDto orderDto)
    {
        var order = new Order
        {
            OrderDate = orderDto.OrderDate,
            TotalAmount = orderDto.TotalAmount,
            UserId = orderDto.UserId,
            OrderItems = orderDto.OrderItems.Select(oi => new OrderItem
            {
                ItemId = oi.ItemId,
                Quantity = oi.Quantity,
                PriceAtPurchase = oi.PriceAtPurchase
            }).ToList()
        };
        await _orderRepository.AddAsync(order);
    }

    public async Task UpdateOrderAsync(OrderDto orderDto)
    {
        var order = await _orderRepository.GetByIdAsync(orderDto.Id);
        if (order != null)
        {
            order.OrderDate = orderDto.OrderDate;
            order.TotalAmount = orderDto.TotalAmount;
            await _orderRepository.UpdateAsync(order);
        }
    }

    public async Task DeleteOrderAsync(long id)
    {
        await _orderRepository.DeleteAsync(id);
    }
}

