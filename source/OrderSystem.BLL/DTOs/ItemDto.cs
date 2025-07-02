namespace OrderSystem.BLL.DTOs;

public class ItemDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string ImageUrl { get; set; }
    public bool IsAvailable { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public long CategoryId { get; set; }
    public string CategoryName { get; set; }

    public long SellerId { get; set; }
    public string SellerName { get; set; }
}
