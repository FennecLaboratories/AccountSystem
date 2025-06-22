namespace OrderSystem.DataAccess.Entities;

public class Category
{
    
    public long Id { get; set; }
    public string Name { get; set; }

    public long WishlistId { get; set; }
    public Wishlist Wishlist { get; set; }
    public long ItemId { get; set; }
    public Item Item { get; set; }
}