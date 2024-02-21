using WholesaleStore.Services.Settings;
using WholesaleStore.Services.Logger;

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
            ;

        return services;
    }
}









