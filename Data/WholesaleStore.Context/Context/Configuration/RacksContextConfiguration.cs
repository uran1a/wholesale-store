using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class RacksContextConfiguration
{
    public static void ConfigureRacks(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rack>().ToTable("racks");
        modelBuilder.Entity<Rack>().Property(x => x.PositionX).IsRequired();
        modelBuilder.Entity<Rack>().Property(x => x.PositionY).IsRequired();
        modelBuilder.Entity<Rack>().Property(x => x.Length).IsRequired();
        modelBuilder.Entity<Rack>().Property(x => x.Width).IsRequired();
        modelBuilder.Entity<Rack>().Property(x => x.Height).IsRequired();

        modelBuilder.Entity<Rack>().HasOne(x => x.Warehouse).WithMany(x => x.Racks).HasForeignKey(x => x.WarehouseId).OnDelete(DeleteBehavior.Restrict);
    }
}
