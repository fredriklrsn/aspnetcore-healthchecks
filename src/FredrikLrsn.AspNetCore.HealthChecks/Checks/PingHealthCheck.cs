using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FredrikLrsn.AspNetCore.HealthChecks.Checks;

/// <summary>
/// A health check for ping.
/// </summary>
public class PingHealthCheck : IHealthCheck
{
    /// <inheritdoc />
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var result = new HealthCheckResult(HealthStatus.Healthy, "Health check is successful.");

        return Task.FromResult(result);
    }
}
