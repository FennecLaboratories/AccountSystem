using Microsoft.AspNetCore.Mvc;
using OrderSystem.BLL.DTOs;
using OrderSystem.BLL.Services;

namespace OrderSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create(OrderDto dto)
    {
        await _orderService.AddOrderAsync(dto);
        return Ok(new { message = "Order created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, OrderDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        await _orderService.UpdateOrderAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _orderService.DeleteOrderAsync(id);
        return NoContent();
    }
}
