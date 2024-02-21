using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class CategoriesContextConfiguration
{
    public static void ConfigureCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("categories");
        modelBuilder.Entity<Category>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<Category>().Property(x => x.Title).HasMaxLength(250);
        modelBuilder.Entity<Category>().HasMany(x => x.Products).WithMany(x => x.Categories).UsingEntity(t => t.ToTable("products_categories"));
    }
}
