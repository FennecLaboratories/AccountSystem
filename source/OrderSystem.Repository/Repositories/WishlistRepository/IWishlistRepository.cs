using OrderSystem.DataAccess.Entities;
namespace OrderSystem.Repository.Repositories.WishlistRepository;

public interface IWishlistRepository : IBaseRepository<Wishlist>
{
    Task<IEnumerable<Wishlist>> GetUserWishlistsAsync(int userId);
    Task<Wishlist?> GetWishlistWithItemsAsync(int id);
}