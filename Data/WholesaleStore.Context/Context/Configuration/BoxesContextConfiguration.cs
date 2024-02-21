using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Context.Configuration;

public static class BoxesContextConfiguration
{
    public static void ConfigureBoxes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box>().ToTable("boxes");
        modelBuilder.Entity<Box>().Property(x => x.Length).IsRequired();
        modelBuilder.Entity<Box>().Property(x => x.Width).IsRequired();
        modelBuilder.Entity<Box>().Property(x => x.Height).IsRequired();
        modelBuilder.Entity<Box>().HasOne(x => x.Product).WithOne(x => x.Box).HasPrincipalKey<Box>(x => x.Id);
    }
}
