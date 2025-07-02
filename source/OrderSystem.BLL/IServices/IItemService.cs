using OrderSystem.BLL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystem.BLL.Services;

public interface IItemService
{
    Task<IEnumerable<ItemDto>> GetAllItemsAsync();
    Task<ItemDto?> GetItemByIdAsync(long id);
    Task AddItemAsync(ItemDto itemDto);
    Task UpdateItemAsync(ItemDto itemDto);
    Task DeleteItemAsync(long id);
}
