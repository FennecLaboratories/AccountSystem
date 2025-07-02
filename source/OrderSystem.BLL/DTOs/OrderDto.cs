namespace OrderSystem.BLL.DTOs;


public class OrderDto
{
    public long Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public long UserId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
}
