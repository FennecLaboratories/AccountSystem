using OrderSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderSystem.Repository.Repositories.UserRepository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<User>> GetUsersWithWishlistsAsync()
    {
        return await _dbSet
            .Include(u => u.Wishlists)
            .ToListAsync();
    }
}