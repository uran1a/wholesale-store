using WholesaleStore.Services.Settings;

namespace WholesaleStore.Identity;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddLoggerSettings()
            ;

        return services;
    }
}
