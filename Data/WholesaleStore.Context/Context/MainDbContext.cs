using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Context.Configuration;
using WholesaleStore.Context.Entities;
using WholesaleStore.Context.Entities.User;

namespace WholesaleStore.Context.Context;

public class MainDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Image> Images { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureProducts();
        modelBuilder.ConfigureCategories();
        modelBuilder.ConfigureUsers();
        modelBuilder.ConfigureImages();
    }
}
