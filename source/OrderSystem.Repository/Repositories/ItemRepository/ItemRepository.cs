using OrderSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
namespace OrderSystem.Repository.Repositories.ItemRepository;

public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    public ItemRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Item>> GetItemsByCategoryAsync(int categoryId)
    {
        return await _dbSet
            .Where(i => i.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetItemsWithCategoryAsync()
    {
        return await _dbSet
            .Include(i => i.Category)
            .ToListAsync();
    }

    public async Task<Item?> GetItemWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(i => i.Category)
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}