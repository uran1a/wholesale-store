using Duende.IdentityServer.Models;
using IdentityModel;
using WholesaleStore.Common.Security;

namespace WholesaleStore.Identity.Configuration.IS;

public static class AppClients
{
    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets =
                {
                    new Secret("A3F0811F2E934C4FB054CB693F7D785E".ToSha256())
                },
                AllowedGrantTypes = GrantTypes.ClientCredentials, // учетные данные клиента
                AccessTokenLifetime = 3600, // 1 час
                AllowedScopes = {
                    AppScopes.ProductsRead,
                    AppScopes.ProductsWrite
                }
            },
            new Client
            {
                ClientId = "frontend",
                ClientSecrets =
                {
                    new Secret("A3F0811F2E934C4FB054CB693F7D785E".ToSha256())
                },
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword, // имя пользователя и пароль
                AllowOfflineAccess = true, 
                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 3600,

                RefreshTokenUsage = TokenUsage.OneTimeOnly,
                RefreshTokenExpiration = TokenExpiration.Sliding,
                AbsoluteRefreshTokenLifetime = 2592000, // 30 дней
                SlidingRefreshTokenLifetime = 1296000, // 15 дней

                AllowedScopes =
                {
                    AppScopes.ProductsRead,
                    AppScopes.ProductsWrite
                }
            }
        };
}
