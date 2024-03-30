using Microsoft.AspNetCore.Identity;

namespace WholesaleStore.Auth.Entities
{
    public class RefreshableIdentityUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
    }
}
