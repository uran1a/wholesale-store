using WholesaleStore.Services.Settings;

namespace WholesaleStore.Api;

public static class Bootstraper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddLoggerSettings()
            ;

        return services;
    }
}
