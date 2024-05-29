using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class CategoriesContextConfiguration
{
    public static void ConfigureCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("categories");
        modelBuilder.Entity<Category>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(250);
        modelBuilder.Entity<Category>().Property(x => x.Image).IsRequired();
        modelBuilder.Entity<Category>().Property(x => x.Image).HasMaxLength(250);
    }
}
