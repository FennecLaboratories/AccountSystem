using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories;

public interface IItemRepository : IBaseRepository<Item>
{
    Task<IEnumerable<Item>> GetItemsByCategoryAsync(int categoryId);
    Task<IEnumerable<Item>> GetItemsWithCategoryAsync();
    Task<Item?> GetItemWithDetailsAsync(int id);
}