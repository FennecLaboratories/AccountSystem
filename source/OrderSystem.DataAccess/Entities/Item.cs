namespace OrderSystem.DataAccess.Entities;

public class Item
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; }
    public bool IsAvailable { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }
    
    public long SellerId { get; set; }
    public User Seller { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
    public ICollection<Wishlist> Wishlists { get; set; }
}