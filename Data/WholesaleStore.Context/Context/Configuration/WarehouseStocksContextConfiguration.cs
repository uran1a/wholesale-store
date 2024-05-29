using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class WarehouseStocksContextConfiguration
{
    public static void ConfigureWarehouseStocks(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WarehouseStock>().ToTable("warehouse_stocks");
        modelBuilder.Entity<WarehouseStock>().Property(x => x.Quentity).IsRequired();
        modelBuilder.Entity<WarehouseStock>().HasOne(x => x.Warehouse).WithMany(x => x.WarehouseStocks).HasForeignKey(x => x.WarehouseId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<WarehouseStock>().HasOne(x => x.Product).WithMany(x => x.WarehouseStocks).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
    }
}
