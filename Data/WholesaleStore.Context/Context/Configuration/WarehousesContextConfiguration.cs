using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class WarehousesContextConfiguration
{
    public static void ConfigureWarehouses(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Warehouse>().ToTable("warehouses");
        modelBuilder.Entity<Warehouse>().Property(x => x.Address).IsRequired();
        modelBuilder.Entity<Warehouse>().Property(x => x.Address).HasMaxLength(250);
    }
}
