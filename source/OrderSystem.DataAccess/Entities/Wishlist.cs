namespace OrderSystem.DataAccess.Entities;

public class Wishlist
{
    public long Id { get; set; }
    public string Title { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public ICollection<Category> Categories { get; set; }
}