using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderSystem.DataAccess.Entities;
namespace OrderSystem.DataAccess.Configurations;
public class WishlistConfigurations : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.ToTable("Wishlist");
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Title).IsRequired().HasMaxLength(100);
        builder.HasOne(w => w.User)
            .WithMany()
            .HasForeignKey(w => w.UserId);
        builder.HasOne(w=>w.Item).WithMany().HasForeignKey(w=>w.ItemId);
    }
}