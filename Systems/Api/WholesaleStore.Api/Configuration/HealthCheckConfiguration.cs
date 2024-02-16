using System.ComponentModel;
using WholesaleStore.Api.Configuration.HealthCheck;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using WholesaleStore.Common.HealthChecks;

namespace WholesaleStore.Api.Configuration;

public static class HealthCheckConfiguration
{
    public static IServiceCollection AddAppHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddCheck<SelfHealthCheck>("WholesaleStore.Api");

        return services;
    }

    public static void UseAppHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");

        app.MapHealthChecks("/health/detail", new HealthCheckOptions
        {
            ResponseWriter = HealthCheckHelper.WriteHealthCheckResponse,
            AllowCachingResponses = false
        });
    }
}
