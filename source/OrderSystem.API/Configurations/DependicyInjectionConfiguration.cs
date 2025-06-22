using FluentValidation;
using OrderSystem.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
namespace OrderSystem.API.Configurations;

public static class DependicyInjectionConfiguration
{
    public static void ConfigureDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IItemRepository, ItemRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
    }
}