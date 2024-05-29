using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;
public static class UsersContextConfiguration
{
    public static void ConfigureUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(250);
        modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(250);
        modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(250);
        modelBuilder.Entity<User>().Property(x => x.Avatar).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.Avatar).HasMaxLength(250);
        modelBuilder.Entity<User>().Property(x => x.Status).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.Role).IsRequired();
    }
}