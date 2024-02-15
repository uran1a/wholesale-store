using Microsoft.Extensions.DependencyInjection;
using WholesaleStore.Services.Logger.Logger;

namespace WholesaleStore.Services.Logger;

public static class Bootstrapper
{
    public static IServiceCollection AddAppLogger(this IServiceCollection services)
    {
        return services
            .AddSingleton<IAppLogger, AppLogger>();
    }
}
