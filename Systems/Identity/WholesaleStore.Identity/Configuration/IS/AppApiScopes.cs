using Duende.IdentityServer.Models;
using WholesaleStore.Common.Security;

namespace WholesaleStore.Identity.Configuration.IS;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.ProductsRead, "Read"),
            new ApiScope(AppScopes.ProductsWrite, "Write")
        };
}
