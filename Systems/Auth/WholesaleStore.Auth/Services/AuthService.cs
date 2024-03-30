using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WholesaleStore.Auth.Entities;
using WholesaleStore.Auth.Models;
using WholesaleStore.Services.Settings.Settings;

namespace WholesaleStore.Auth.Services
{
    public class AuthService(UserManager<RefreshableIdentityUser> userManager, JwtSettings settings) : IAuthService
    {
        private readonly UserManager<RefreshableIdentityUser> userManager = userManager;
        private readonly JwtSettings settings = settings;

        public string GenerateToken(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(20),
                signingCredentials: signingCred);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];

            using (var numberGenerator = RandomNumberGenerator.Create())
                numberGenerator.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        public async Task<LoginResponse> Login(LoginUser user)
        {
            var response = new LoginResponse();

            var identityUser = await userManager.FindByEmailAsync(user.UserName);
            if (identityUser is null || !(await userManager.CheckPasswordAsync(identityUser, user.Password)))
                return response;

            response.IsLogedIn = true;
            response.JwtToken = GenerateToken(identityUser.Email);
            response.RefreshToken = GenerateRefreshToken();

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.AddHours(12);
            await userManager.UpdateAsync(identityUser);

            return response;
        }

        private ClaimsPrincipal? GetTokenPrincipal(string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key));
            var validation = new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateLifetime = false,
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }

        public async Task<LoginResponse> RefreshToken(TokenPair pair)
        {
            var principal = GetTokenPrincipal(pair.JwtToken);

            var respose = new LoginResponse();
            if (principal?.Identity?.Name is null)
                return respose;

            var identityUser = await userManager.FindByEmailAsync(principal.Identity.Name);

            if (identityUser is null || identityUser.RefreshToken != pair.RefreshToken || identityUser.RefreshTokenExpiry < DateTime.Now)
                return respose;

            respose.IsLogedIn = true;
            respose.JwtToken = GenerateToken(identityUser.Email);
            respose.RefreshToken = GenerateRefreshToken();

            identityUser.RefreshToken = respose.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.AddHours(12);
            await userManager.UpdateAsync(identityUser);

            return respose;
        }

        public async Task<bool> RegisterUser(LoginUser user)
        {
            var identityUser = new RefreshableIdentityUser
            {
                UserName = user.UserName,
                Email = user.UserName
            };

            var result = await userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }
    }
}
