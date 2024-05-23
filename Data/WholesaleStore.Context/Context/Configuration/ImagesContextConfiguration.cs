using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class ImagesContextConfiguration
{
    public static void ConfigureImages(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Image>().ToTable("images");
        modelBuilder.Entity<Image>().Property(x => x.Url).IsRequired();
        modelBuilder.Entity<Image>().Property(x => x.Url).HasMaxLength(250);
        modelBuilder.Entity<Image>().HasOne(x => x.Product).WithMany(x => x.Images).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
    }
}
