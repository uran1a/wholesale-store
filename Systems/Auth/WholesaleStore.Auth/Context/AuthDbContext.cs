using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Auth.Entities;

namespace WholesaleStore.Auth.Context
{
    public class AuthDbContext : IdentityDbContext
    {
        public DbSet<RefreshableIdentityUser> RefreshableIdentityUsers { get; set; }
        public AuthDbContext(DbContextOptions options) : base(options) { }
    }
}
