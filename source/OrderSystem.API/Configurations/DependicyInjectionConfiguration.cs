using FluentValidation;
using OrderSystem.Repository.Repositories.CategoryRepository;
using OrderSystem.Repository.Repositories.OrderItemRepository;
using OrderSystem.Repository.Repositories.OrderRepository;
using OrderSystem.Repository.Repositories.UserRepository;
using OrderSystem.Repository.Repositories.WishlistRepository;
using OrderSystem.Repository.Repositories.ItemRepository;
using OrderSystem.Repository;
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