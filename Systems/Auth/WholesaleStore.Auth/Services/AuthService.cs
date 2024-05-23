using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
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

        private string GenerateToken(string userName, string signature, int age)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("iat", DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signature));
            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(age),
                signingCredentials: signingCred);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);

           /* var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.ASCII.GetBytes(key);

            var iat = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "123"),
                    new Claim(ClaimTypes.Name, "John Doe"),
                    new Claim("iss", "your_issuer"),
                    new Claim("iat", DateTime.Now.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddSeconds(age);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            
            var payload = new JwtPayload
            {
                {"sub", username},
                {"iss", _options.Issuer},
                {"iat", iat},
                {"exp", exp},
                {"unique_name", username},
            };
            var tokenn = new JwtPayload(claims);
            tokenn.
            var jwt = new JwtSecurityToken(_jwtHeader, payload);*/
        }

        public async Task<LoginResponse> Login(LoginUser user)
        {
            var response = new LoginResponse();

            var identityUser = await userManager.FindByEmailAsync(user.Login);
            if (identityUser is null || !(await userManager.CheckPasswordAsync(identityUser, user.Password)))
                return response;

            response.IsLogedIn = true;
            response.AccessToken = GenerateToken(identityUser.Email, settings.SignatureAccess, int.Parse(settings.AccessTokenAge));
            response.RefreshToken = GenerateToken(identityUser.Email, settings.SignatureRefresh, int.Parse(settings.RefreshTokenAge));

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.AddSeconds(int.Parse(settings.RefreshTokenAge));
            await userManager.UpdateAsync(identityUser);

            return response;
        }

        private ClaimsPrincipal? GetTokenPrincipal(string token, string signature)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signature));
            var validation = new TokenValidationParameters
            {
                IssuerSigningKey = securityKey,
                ValidateLifetime = true,
                ValidateActor = false,
                ValidateIssuer = false,
                ValidateAudience = false
            };

            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }

        public async Task<LoginResponse> RefreshTokens(string refreshToken)
        {
            var principal = GetTokenPrincipal(refreshToken, settings.SignatureRefresh);

            var respose = new LoginResponse();
            if (principal?.Identity?.Name is null)
                return respose;

            //var identityUser = await userManager.FindByEmailAsync(principal.Identity.Name);
/*
            if (identityUser is null || identityUser.RefreshToken != pair.RefreshToken || identityUser.RefreshTokenExpiry < DateTime.Now)
                return respose;*/

            respose.IsLogedIn = true;
            respose.AccessToken = GenerateToken(principal.Identity.Name, settings.SignatureAccess, int.Parse(settings.AccessTokenAge));
            respose.RefreshToken = GenerateToken(principal.Identity.Name, settings.SignatureRefresh, int.Parse(settings.RefreshTokenAge));

           /* identityUser.RefreshToken = respose.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.AddHours(int.Parse(settings.RefreshTokenAge));
            await userManager.UpdateAsync(identityUser);*/

            return respose;
        }

        public async Task<bool> RegisterUser(LoginUser user)
        {
            var identityUser = new RefreshableIdentityUser
            {
                UserName = user.Login,
                Email = user.Login
            };

            var result = await userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }
    }
}
