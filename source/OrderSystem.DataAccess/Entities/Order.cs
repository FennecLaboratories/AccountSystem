namespace OrderSystem.DataAccess.Entities;

public class Order
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Status { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}