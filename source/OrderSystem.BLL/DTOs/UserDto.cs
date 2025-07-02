namespace OrderSystem.BLL.DTOs;


public class UserDto
{
	public long Id { get; set; }
	public string Username { get; set; }
	public string Email { get; set; }

	public string FirstName { get; set; }
	public string LastName { get; set; }

	public string Description { get; set; }
	public string ProfileImage { get; set; }

	public string Role { get; set; }

	public List<WishlistDto> Wishlists { get; set; }
	public List<OrderDto> Orders { get; set; }
}
