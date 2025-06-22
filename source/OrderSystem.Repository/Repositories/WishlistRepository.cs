using OrderSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderSystem.Repository.Repositories;

public class WishlistRepository : BaseRepository<Wishlist>, IWishlistRepository
{
    public WishlistRepository(DbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Wishlist>> GetUserWishlistsAsync(int userId)
    {
        return await _dbSet
            .Include(w => w.Item)
            .Where(w => w.UserId == userId)
            .ToListAsync();
    }

    public async Task<Wishlist?> GetWishlistWithItemsAsync(int id)
    {
        return await _dbSet
            .Include(w => w.Item)
            .FirstOrDefaultAsync(w => w.Id == id);
    }
}