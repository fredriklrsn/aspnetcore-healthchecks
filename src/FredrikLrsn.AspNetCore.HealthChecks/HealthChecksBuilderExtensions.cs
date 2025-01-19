using FredrikLrsn.AspNetCore.HealthChecks.Checks;
using Microsoft.Extensions.DependencyInjection;

namespace FredrikLrsn.AspNetCore.HealthChecks;

public static class HealthChecksBuilderExtensions
{
    /// <summary>
    /// Add a health check for ping.
    /// </summary>
    /// <param name="builder">The <see cref="IHealthChecksBuilder"/>.</param>
    /// <param name="name">The name of the health check.</param>
    /// <param name="tags">A list of tags that can be used to filter sets of health checks. Optional.</param>
    /// <returns></returns>
    public static IHealthChecksBuilder AddPing(this IHealthChecksBuilder builder, string name = "Ping", IEnumerable<string>? tags = default)
    {
        return builder.AddCheck<PingHealthCheck>(name, tags: tags);
    }
}
