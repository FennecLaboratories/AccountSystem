using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderSystem.DataAccess.Entities;
namespace OrderSystem.DataAccess.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.OrderDate).IsRequired();
        builder.Property(o => o.TotalAmount).IsRequired();
        
        builder.HasOne(o => o.User)
            .WithMany()
            .HasForeignKey(o => o.UserId);
    }
}