namespace OrderSystem.BLL.DTOs;


public class WishlistDto
{
	public long Id { get; set; }
	public string Title { get; set; }

	public long UserId { get; set; }

	public ItemDto Item { get; set; }

	public List<CategoryDto> Categories { get; set; }
}
