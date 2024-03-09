using WholesaleStore.Services.Settings;
using WholesaleStore.Services.Logger;
using WholesaleStore.Services.Products;
using WholesaleStore.Services.UserAccount;

namespace WholesaleStore.Api;

public static class Bootstraper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration = null)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddLoggerSettings()
            .AddAppLogger() 
            .AddProductService()
            .AddUserAccountService()
            ;

        return services;
    }
}









