using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace WholesaleStore.Identity.Configuration.HealthChecks;

public class SelfHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var assembly = Assembly.Load("NetSchool.Identity");
        var versionNumber = assembly.GetName().Version;

        return Task.FromResult(HealthCheckResult.Healthy(description: $"Build {versionNumber}"));
    }
}

