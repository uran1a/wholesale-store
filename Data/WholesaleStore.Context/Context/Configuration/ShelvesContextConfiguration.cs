using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class ShelvesContextConfiguration
{
    public static void ConfigureShelves(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shelf>().ToTable("shelves");
        modelBuilder.Entity<Shelf>().Property(x => x.Level).IsRequired();
        modelBuilder.Entity<Shelf>().Property(x => x.Height).IsRequired();
        modelBuilder.Entity<Shelf>().Property(x => x.LoadCapacity).IsRequired();

        modelBuilder.Entity<Shelf>().HasOne(x => x.Rack).WithMany(x => x.Shelves).HasForeignKey(x => x.RackId).OnDelete(DeleteBehavior.Restrict);
    }
}
