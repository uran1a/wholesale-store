namespace WholesaleStore.Common.HealthChecks;

public class HealthCheck
{
    public string OverallStatus { get; set; } = default!;
    public IEnumerable<HealthCheckItem> HealthChecks { get; set; } = default!;
    public string TotalDuration { get; set; } = default!;
}

public class HealthCheckItem
{
    public string Status { get; set; } = default!;
    public string Component { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Duration { get; set; } = default!; 
}