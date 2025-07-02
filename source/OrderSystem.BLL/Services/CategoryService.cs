using OrderSystem.BLL.DTOs;
using OrderSystem.BLL.Services;
using OrderSystem.DataAccess.Entities;
using OrderSystem.Repository.Repositories.CategoryRepository;
using OrderSystem.Repository.Repositories.ItemRepository;
using OrderSystem.Repository.Repositories.OrderRepository;
using OrderSystem.Repository.Repositories.UserRepository;
using OrderSystem.Repository.Repositories.WishlistRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.BLL.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name
        });
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(long id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return category == null ? null : new CategoryDto { Id = category.Id, Name = category.Name };
    }

    public async Task AddCategoryAsync(CategoryDto categoryDto)
    {
        var category = new Category { Name = categoryDto.Name };
        await _categoryRepository.AddAsync(category);
    }

    public async Task UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryDto.Id);
        if (category != null)
        {
            category.Name = categoryDto.Name;
            await _categoryRepository.UpdateAsync(category);
        }
    }

    public async Task DeleteCategoryAsync(long id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}