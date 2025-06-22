using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetUsersWithWishlistsAsync();
}