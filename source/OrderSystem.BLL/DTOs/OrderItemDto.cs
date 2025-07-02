namespace OrderSystem.BLL.DTOs;

public class OrderItemDto
{
    public long OrderId { get; set; }
    public long ItemId { get; set; }
    public string? ItemName { get; set; } 
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
}
