using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class OrdersContextConfiguration
{
    public static void ConfigureOrders(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().ToTable("orders");
        modelBuilder.Entity<Order>().Property(x => x.OrderDate).IsRequired();
        modelBuilder.Entity<Order>().Property(x => x.TotalAmount).IsRequired();
        modelBuilder.Entity<Order>().Property(x => x.Status).IsRequired();
        modelBuilder.Entity<Order>().Property(x => x.UserId).IsRequired();
        modelBuilder.Entity<Order>().HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}
