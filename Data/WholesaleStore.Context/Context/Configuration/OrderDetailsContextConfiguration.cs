using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class OrderDetailsContextConfiguration
{
    public static void ConfigureOrderDetails(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>().ToTable("order_details");
        modelBuilder.Entity<OrderDetail>().Property(x => x.Quantity).IsRequired();
        modelBuilder.Entity<OrderDetail>().Property(x => x.Price).IsRequired();
        modelBuilder.Entity<OrderDetail>().Property(x => x.OrderId).IsRequired();
        modelBuilder.Entity<OrderDetail>().Property(x => x.ProductId).IsRequired();
        modelBuilder.Entity<OrderDetail>().HasOne(x => x.Order).WithMany(x => x.OrderDetails).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<OrderDetail>().HasOne(x => x.Product).WithMany(x => x.OrderDetails).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
    }
}
