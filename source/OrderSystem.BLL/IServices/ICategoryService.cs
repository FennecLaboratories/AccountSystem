using OrderSystem.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystem.BLL.Services;


public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto?> GetCategoryByIdAsync(long id);
    Task AddCategoryAsync(CategoryDto categoryDto);
    Task UpdateCategoryAsync(CategoryDto categoryDto);
    Task DeleteCategoryAsync(long id);
}
