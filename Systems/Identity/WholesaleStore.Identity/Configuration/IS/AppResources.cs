using Duende.IdentityServer.Models;

namespace WholesaleStore.Identity.Configuration.IS;

public static class AppResources
{
    public static IEnumerable<ApiResource> Resources => new List<ApiResource>
    {
        new ApiResource("api")
    };
}
