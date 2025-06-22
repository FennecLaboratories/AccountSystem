namespace OrderSystem.DataAccess.Entities;

public class OrderItem
{
    public long OrderId { get; set; }
    public Order Order { get; set; }
    
    public long ItemId { get; set; }
    public Item Item { get; set; }
    
    public int Quantity { get; set; }
    public decimal PriceAtPurchase { get; set; }
}