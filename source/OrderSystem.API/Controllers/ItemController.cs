using Microsoft.AspNetCore.Mvc;
using OrderSystem.BLL.DTOs;
using OrderSystem.BLL.Services;

namespace OrderSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _itemService.GetAllItemsAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var item = await _itemService.GetItemByIdAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ItemDto dto)
    {
        await _itemService.AddItemAsync(dto);
        return Ok(new { message = "Item created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, ItemDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        await _itemService.UpdateItemAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _itemService.DeleteItemAsync(id);
        return NoContent();
    }
}
