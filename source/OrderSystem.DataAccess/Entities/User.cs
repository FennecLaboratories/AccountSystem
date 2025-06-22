namespace OrderSystem.DataAccess.Entities;

public class User
{
    public long Id { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Description { get; set; }    
    public string PasswordHash { get; set; }   
    public string ProfileImage { get; set; }   
    public UserRole Role { get; set; } = UserRole.Customer;


    public ICollection<Order> Orders { get; set; }
    public ICollection<Wishlist> Wishlists { get; set; }
}
public enum UserRole
{
    Customer,
    Seller,
    Admin
}
