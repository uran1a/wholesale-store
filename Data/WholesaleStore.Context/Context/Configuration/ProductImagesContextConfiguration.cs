using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class ProductImagesContextConfiguration
{
    public static void ConfigureProductImages(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductImage>().ToTable("product_images");
        modelBuilder.Entity<ProductImage>().Property(x => x.Url).IsRequired();
        modelBuilder.Entity<ProductImage>().Property(x => x.Url).HasMaxLength(250);
        modelBuilder.Entity<ProductImage>().HasOne(x => x.Product).WithMany(x => x.Images).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
    }
}
