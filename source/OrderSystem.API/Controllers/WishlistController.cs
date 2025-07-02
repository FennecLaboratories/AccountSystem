using Microsoft.AspNetCore.Mvc;
using OrderSystem.BLL.DTOs;
using OrderSystem.BLL.Services;

namespace OrderSystem.API.Controllers;

[ApiController]

[Route("api/[controller]")]
public class WishlistsController : ControllerBase
{
    private readonly IWishlistService _wishlistService;

    public WishlistsController(IWishlistService wishlistService)
    {
        _wishlistService = wishlistService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _wishlistService.GetAllWishlistsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var wishlist = await _wishlistService.GetWishlistByIdAsync(id);
        return wishlist == null ? NotFound() : Ok(wishlist);
    }

    [HttpPost]
    public async Task<IActionResult> Create(WishlistDto dto)
    {
        await _wishlistService.AddWishlistAsync(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, WishlistDto dto)
    {
        if (id != dto.Id) return BadRequest();
        await _wishlistService.UpdateWishlistAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _wishlistService.DeleteWishlistAsync(id);
        return NoContent();
    }
}
