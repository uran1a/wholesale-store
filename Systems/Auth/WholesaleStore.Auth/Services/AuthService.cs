using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WholesaleStore.Auth.Models;
using WholesaleStore.Services.Settings.Settings;

namespace WholesaleStore.Auth.Services
{
    public class AuthService(UserManager<IdentityUser> userManager, JwtSettings settings) : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager = userManager;
        private readonly JwtSettings settings = settings;

        public string GenerateToken(LoginUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserName),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: settings.Issuer,
                audience: settings.Audience,
                signingCredentials: signingCred);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public async Task<bool> Login(LoginUser user)
        {
            var identityUser = await userManager.FindByEmailAsync(user.UserName);
            if (identityUser is null)
                return false;

            return await userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public async Task<bool> RegisterUser(LoginUser user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.UserName
            };

            var result = await userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }
    }
}
