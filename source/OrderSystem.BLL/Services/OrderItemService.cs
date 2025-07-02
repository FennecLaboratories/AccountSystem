using OrderSystem.BLL.DTOs;
using OrderSystem.DataAccess.Entities;
using OrderSystem.Repository.Repositories.OrderItemRepository;

namespace OrderSystem.BLL.Services;


public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task<IEnumerable<OrderItemDto>> GetAllAsync()
    {
        var orderItems = await _orderItemRepository.GetAllWithItemAsync();
        return orderItems.Select(oi => new OrderItemDto
        {
            OrderId = oi.OrderId,
            ItemId = oi.ItemId,
            ItemName = oi.Item?.Name,
            Quantity = oi.Quantity,
            PriceAtPurchase = oi.PriceAtPurchase
        });
    }

    public async Task<OrderItemDto?> GetByOrderAndItemIdAsync(long orderId, long itemId)
    {
        var orderItem = await _orderItemRepository.GetByOrderAndItemIdWithItemAsync(orderId, itemId);
        if (orderItem == null) return null;

        return new OrderItemDto
        {
            OrderId = orderItem.OrderId,
            ItemId = orderItem.ItemId,
            ItemName = orderItem.Item?.Name,
            Quantity = orderItem.Quantity,
            PriceAtPurchase = orderItem.PriceAtPurchase
        };
    }

    public async Task AddAsync(OrderItemDto dto)
    {
        var entity = new OrderItem
        {
            OrderId = dto.OrderId,
            ItemId = dto.ItemId,
            Quantity = dto.Quantity,
            PriceAtPurchase = dto.PriceAtPurchase
        };
        await _orderItemRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(OrderItemDto dto)
    {
        var existing = await _orderItemRepository.GetByOrderAndItemIdAsync(dto.OrderId, dto.ItemId);
        if (existing != null)
        {
            existing.Quantity = dto.Quantity;
            existing.PriceAtPurchase = dto.PriceAtPurchase;
            await _orderItemRepository.UpdateAsync(existing);
        }
    }

    public async Task DeleteAsync(long orderId, long itemId)
    {
        await _orderItemRepository.DeleteAsync(orderId, itemId);
    }
}
