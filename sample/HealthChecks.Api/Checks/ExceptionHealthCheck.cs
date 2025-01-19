using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.Api.Checks;

internal class ExceptionHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var exception = new Exception("Exception message.", new Exception("Inner exception message."));
        var result = new HealthCheckResult(HealthStatus.Unhealthy, "Expected exception.", exception);

        return Task.FromResult(result);
    }
}
