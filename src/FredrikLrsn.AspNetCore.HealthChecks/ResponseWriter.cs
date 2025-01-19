using FredrikLrsn.AspNetCore.HealthChecks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FredrikLrsn.AspNetCore.HealthChecks;

internal static class ResponseWriter
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = BuildJsonSerializerOptions();

    public static async Task Write(HttpContext httpContext, HealthReport report)
    {
        httpContext.Response.ContentType = "application/json";

        var response = new HealthResponse(
            report.Status,
            DateTimeOffset.UtcNow,
            report.TotalDuration.Milliseconds,
            report.Entries.Select(x => new HealthCheckResponse(
                x.Key,
                x.Value.Status,
                x.Value.Duration.Milliseconds,
                x.Value.Description,
                x.Value.Exception)).ToList()
            );

        var jsonResponse = JsonSerializer.Serialize(response, _jsonSerializerOptions);

        await httpContext.Response.WriteAsync(jsonResponse);
    }

    private static JsonSerializerOptions BuildJsonSerializerOptions()
    {
        var jsonSerializerOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        return jsonSerializerOptions;
    }
}
