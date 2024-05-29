using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Context.Configuration;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context;

public class MainDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<WarehouseStock> WarehouseStocks { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureProducts();
        modelBuilder.ConfigureCategories();
        modelBuilder.ConfigureUsers();
        modelBuilder.ConfigureProductImages();
        modelBuilder.ConfigureOrders();
        modelBuilder.ConfigureOrderDetails();
        modelBuilder.ConfigureWarehouses();
        modelBuilder.ConfigureWarehouseStocks();
    }
}
