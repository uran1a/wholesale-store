using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class ProductsContextConfiguration
{
    public static void ConfigureProducts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Product>().Property(x => x.Title).IsRequired();
        modelBuilder.Entity<Product>().Property(x => x.Title).HasMaxLength(250);
        modelBuilder.Entity<Product>().Property(x => x.Description).IsRequired();
        modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired();
        modelBuilder.Entity<Product>().Property(x => x.Quantity).IsRequired();
        modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
        //modelBuilder.Entity<Product>().HasMany(x => x.Images).WithOne(x => x.Product);
    }
}
