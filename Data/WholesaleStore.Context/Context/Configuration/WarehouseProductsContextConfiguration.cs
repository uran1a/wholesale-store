using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class WarehouseProductsContextConfiguration
{
    public static void ConfigureWarehouseProducts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WarehouseProduct>().ToTable("warehouse_products");
        modelBuilder.Entity<WarehouseProduct>().Property(x => x.PositionX).IsRequired();
        modelBuilder.Entity<WarehouseProduct>().Property(x => x.PositionY).IsRequired();
        modelBuilder.Entity<WarehouseProduct>().HasOne(x => x.Product).WithMany(x => x.WarehouseProducts).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<WarehouseProduct>().HasOne(x => x.Shelf).WithMany(x => x.WarehouseProducts).HasForeignKey(x => x.ShelfId).OnDelete(DeleteBehavior.Restrict);
    }
}
