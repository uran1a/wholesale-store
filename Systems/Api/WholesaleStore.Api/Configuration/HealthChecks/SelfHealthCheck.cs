using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace WholesaleStore.Api.Configuration.HealthCheck;
public class SelfHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
        CancellationToken cancellationToken = default)
    {
        var assembly = Assembly.Load("WholesaleStore.Api");
        var versionNumber = assembly.GetName().Version;

        return Task.FromResult(HealthCheckResult.Healthy($"Build {versionNumber}"));
    }
}
