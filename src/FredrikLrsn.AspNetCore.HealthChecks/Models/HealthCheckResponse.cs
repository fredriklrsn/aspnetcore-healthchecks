using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FredrikLrsn.AspNetCore.HealthChecks.Models;

/// <summary>
/// Information about health check.
/// </summary>
/// <param name="Name">The name of the health check.</param>
/// <param name="Status">The status of the health check.</param>
/// <param name="Duration">The duration of the health check.</param>
/// <param name="Description">The description of the health check if any.</param>
/// <param name="Exception">The exception of the health check if any.</param>
public sealed record HealthCheckResponse(
    string Name,
    HealthStatus Status,
    int Duration,
    string? Description,
    Exception? Exception);
