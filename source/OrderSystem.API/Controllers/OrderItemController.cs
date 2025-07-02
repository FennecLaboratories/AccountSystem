using Microsoft.AspNetCore.Mvc;
using OrderSystem.BLL.DTOs;
using OrderSystem.BLL.Services;

namespace OrderSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemService _service;

    public OrderItemsController(IOrderItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{orderId}/{itemId}")]
    public async Task<IActionResult> Get(long orderId, long itemId)
    {
        var result = await _service.GetByOrderAndItemIdAsync(orderId, itemId);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderItemDto dto)
    {
        await _service.AddAsync(dto);
        return Ok(new { message = "OrderItem created" });
    }

    [HttpPut("{orderId}/{itemId}")]
    public async Task<IActionResult> Update(long orderId, long itemId, OrderItemDto dto)
    {
        if (orderId != dto.OrderId || itemId != dto.ItemId)
            return BadRequest("OrderId/ItemId mismatch");

        await _service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{orderId}/{itemId}")]
    public async Task<IActionResult> Delete(long orderId, long itemId)
    {
        await _service.DeleteAsync(orderId, itemId);
        return NoContent();
    }
}

