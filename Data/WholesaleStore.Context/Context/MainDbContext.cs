using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Context.Configuration;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context;

public class MainDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Box> Boxes { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Rack> Racks { get; set; }
    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<WarehouseProduct> WarehouseProducts { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureProducts();
        modelBuilder.ConfigureCategories();
        modelBuilder.ConfigureBoxes();
        modelBuilder.ConfigureWarehouses();
        modelBuilder.ConfigureRacks();
        modelBuilder.ConfigureShelves();
        modelBuilder.ConfigureWarehouseProducts();
    }
}
