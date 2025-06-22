using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
}