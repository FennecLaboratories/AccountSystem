using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories;

public interface IWishlistRepository : IBaseRepository<Wishlist>
{
    Task<IEnumerable<Wishlist>> GetUserWishlistsAsync(int userId);
    Task<Wishlist?> GetWishlistWithItemsAsync(int id);
}