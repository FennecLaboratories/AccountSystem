using Microsoft.AspNetCore.Mvc;
using OrderSystem.BLL.DTOs;
using OrderSystem.BLL.Services.CategoryService;
using System.Threading.Tasks;

namespace OrderSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryService.GetAllCategoriesAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        return category == null ? NotFound() : Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto dto)
    {
        await _categoryService.AddCategoryAsync(dto);
        return Ok(new { message = "Category created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, CategoryDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        await _categoryService.UpdateCategoryAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}
