using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderSystem.DataAccess.Entities;
namespace OrderSystem.DataAccess.Configurations;
public class OrderConfigurations :  IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Order");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Name).IsRequired().HasMaxLength(100);
        builder.Property(o => o.Price).IsRequired();
        builder.Property(o => o.Status).IsRequired().HasMaxLength(10);
    }
}