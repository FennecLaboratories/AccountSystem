using OrderSystem.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystem.BLL.Services;

public interface IWishlistService
{
	Task<IEnumerable<WishlistDto>> GetAllWishlistsAsync();
	Task<WishlistDto?> GetWishlistByIdAsync(long id);
	Task AddWishlistAsync(WishlistDto wishlistDto);
	Task UpdateWishlistAsync(WishlistDto wishlistDto);
	Task DeleteWishlistAsync(long id);
}
