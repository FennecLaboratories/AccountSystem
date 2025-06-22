using Microsoft.EntityFrameworkCore;
using OrderSystem.DataAccess.Configurations;
using OrderSystem.DataAccess.Entities;

namespace OrderSystem.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new OrderConfigurations());
        modelBuilder.ApplyConfiguration(new UserConfigurations());
        modelBuilder.ApplyConfiguration(new CategoryConfigurations());
        modelBuilder.ApplyConfiguration(new WishlistConfigurations());
    }
}