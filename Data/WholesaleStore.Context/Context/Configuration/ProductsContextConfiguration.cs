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
        modelBuilder.Entity<Product>().Property(x => x.Weight).IsRequired();
        modelBuilder.Entity<Product>().Property(x => x.Price).IsRequired();
    }
}
