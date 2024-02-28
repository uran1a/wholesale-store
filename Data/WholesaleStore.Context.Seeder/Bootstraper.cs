using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WholesaleStore.Context.Seeder;
public static class Bootstraper
{
    public static IServiceCollection AddDbSeeder(this IServiceCollection services, IConfiguration configuration = null)
    {
        return services;
    }
}
