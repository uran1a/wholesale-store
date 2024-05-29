using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class WarehousesContextConfiguration
{
    public static void ConfigureWarehouses(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Warehouse>().ToTable("warehouses");
        modelBuilder.Entity<Warehouse>().Property(x => x.Location).IsRequired();
        modelBuilder.Entity<Warehouse>().Property(x => x.Location).HasMaxLength(255);
    }
}
