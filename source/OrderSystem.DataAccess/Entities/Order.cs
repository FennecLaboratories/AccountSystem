namespace OrderSystem.DataAccess.Entities;

public class Order
{
    public long Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    
    public long UserId { get; set; }
    public User User { get; set; }
    
    public List<OrderItem> OrderItems { get; set; } = new();
}