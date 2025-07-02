namespace OrderSystem.BLL.Services;


public class WishlistService : IWishlistService
{
    private readonly IWishlistRepository _wishlistRepository;

    public WishlistService(IWishlistRepository wishlistRepository)
    {
        _wishlistRepository = wishlistRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersWithDetailsAsync()
    {
        var users = await _userRepository.GetUsersWithWishlistsAsync();
        return users.Select(MapToUserDto);
    }


    public async Task<WishlistDto?> GetWishlistByIdAsync(long id)
    {
        var wishlist = await _wishlistRepository.GetByIdWithItemAndCategoriesAsync(id);
        if (wishlist == null) return null;

        return new WishlistDto
        {
            Id = wishlist.Id,
            Title = wishlist.Title,
            UserId = wishlist.UserId,
            Item = new ItemDto
            {
                Id = wishlist.Item.Id,
                Name = wishlist.Item.Name,
                Description = wishlist.Item.Description,
                Price = wishlist.Item.Price,
                StockQuantity = wishlist.Item.StockQuantity,
                ImageUrl = wishlist.Item.ImageUrl,
                CategoryId = wishlist.Item.CategoryId,
                SellerId = wishlist.Item.SellerId
            },
            Categories = wishlist.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList()
        };
    }

    public async Task AddWishlistAsync(WishlistDto wishlistDto)
    {
        var wishlist = new Wishlist
        {
            Title = wishlistDto.Title,
            UserId = wishlistDto.UserId,
            ItemId = wishlistDto.Item.Id,
            Categories = wishlistDto.Categories.Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name
            }).ToList()
        };
        await _wishlistRepository.AddAsync(wishlist);
    }

    public async Task UpdateWishlistAsync(WishlistDto wishlistDto)
    {
        var wishlist = await _wishlistRepository.GetByIdAsync(wishlistDto.Id);
        if (wishlist != null)
        {
            wishlist.Title = wishlistDto.Title;
            wishlist.ItemId = wishlistDto.Item.Id;
            await _wishlistRepository.UpdateAsync(wishlist);
        }
    }

    public async Task DeleteWishlistAsync(long id)
    {
        await _wishlistRepository.DeleteAsync(id);
    }
}
