using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.Api.Checks;

public class RandomHealthCheck : IHealthCheck
{
    private static readonly Random _random = new();

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        bool isHealthy = _random.Next(0, 1) == 0;

        await Task.Delay(100, cancellationToken);

        return isHealthy
            ? HealthCheckResult.Healthy("The service is healthy.")
            : HealthCheckResult.Unhealthy("The service is unhealthy.");
    }
}
