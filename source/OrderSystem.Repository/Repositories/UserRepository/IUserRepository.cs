using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories.UserRepository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetUsersWithWishlistsAsync();
}