using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FredrikLrsn.AspNetCore.HealthChecks.Models;

/// <summary>
/// Information about health chekcs.
/// </summary>
/// <param name="Status">The status of the health checks.</param>
/// <param name="Timestamp">The timestamp of the health checks.</param>
/// <param name="Duration">The duration of the health checks.</param>
/// <param name="Checks">The health checks included.</param>
public sealed record HealthResponse(
    HealthStatus Status,
    DateTimeOffset Timestamp,
    int Duration,
    ICollection<HealthCheckResponse> Checks);
