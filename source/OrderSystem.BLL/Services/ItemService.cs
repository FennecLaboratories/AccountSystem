
namespace OrderSystem.BLL.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<ItemDto>> GetAllItemsAsync()
    {
        var items = await _itemRepository.GetAllWithCategoryAndSellerAsync();
        return items.Select(item => new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            StockQuantity = item.StockQuantity,
            ImageUrl = item.ImageUrl,
            IsAvailable = item.IsAvailable,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt,
            CategoryId = item.CategoryId,
            CategoryName = item.Category?.Name,
            SellerId = item.SellerId,
            SellerName = item.Seller?.Username
        });
    }

    public async Task<ItemDto?> GetItemByIdAsync(long id)
    {
        var item = await _itemRepository.GetByIdWithCategoryAndSellerAsync(id);
        return item == null ? null : new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            StockQuantity = item.StockQuantity,
            ImageUrl = item.ImageUrl,
            IsAvailable = item.IsAvailable,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt,
            CategoryId = item.CategoryId,
            CategoryName = item.Category?.Name,
            SellerId = item.SellerId,
            SellerName = item.Seller?.Username
        };
    }

    public async Task AddItemAsync(ItemDto itemDto)
    {
        var item = new Item
        {
            Name = itemDto.Name,
            Description = itemDto.Description,
            Price = itemDto.Price,
            StockQuantity = itemDto.StockQuantity,
            ImageUrl = itemDto.ImageUrl,
            IsAvailable = itemDto.IsAvailable,
            CategoryId = itemDto.CategoryId,
            SellerId = itemDto.SellerId
        };
        await _itemRepository.AddAsync(item);
    }

    public async Task UpdateItemAsync(ItemDto itemDto)
    {
        var item = await _itemRepository.GetByIdAsync(itemDto.Id);
        if (item != null)
        {
            item.Name = itemDto.Name;
            item.Description = itemDto.Description;
            item.Price = itemDto.Price;
            item.StockQuantity = itemDto.StockQuantity;
            item.ImageUrl = itemDto.ImageUrl;
            item.IsAvailable = itemDto.IsAvailable;
            item.CategoryId = itemDto.CategoryId;
            item.SellerId = itemDto.SellerId;
            await _itemRepository.UpdateAsync(item);
        }
    }

    public async Task DeleteItemAsync(long id)
    {
        await _itemRepository.DeleteAsync(id);
    }
}
