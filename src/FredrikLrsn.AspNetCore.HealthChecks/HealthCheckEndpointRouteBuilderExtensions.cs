using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;

namespace FredrikLrsn.AspNetCore.HealthChecks;

public static class HealthCheckEndpointRouteBuilderExtensions
{
    /// <summary>
    /// Adds a health endpoint including all health checks.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/> to add the health checks endpoint to.</param>
    /// <param name="route">The URL pattern of the health checks endpoint.</param>
    /// <returns></returns>
    public static IEndpointConventionBuilder AddHealthEndpoint(this IEndpointRouteBuilder builder, string route)
    {
        return builder.MapHealthChecks(route, new HealthCheckOptions
        {
            ResponseWriter = ResponseWriter.Write
        });
    }

    /// <summary>
    /// Adds a health endpoint including all health checks that matches given names.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/> to add the health checks endpoint to.</param>
    /// <param name="route">The URL pattern of the health checks endpoint.</param>
    /// <param name="names">A list of health check names to include in the endpoint.</param>
    /// <returns></returns>
    public static IEndpointConventionBuilder AddHealthEndpointByNames(this IEndpointRouteBuilder builder, string route, string[] names)
    {
        return builder.MapHealthChecks(route, new HealthCheckOptions
        {
            Predicate = check => names.Contains(check.Name),
            ResponseWriter = ResponseWriter.Write
        });
    }

    /// <summary>
    /// Adds a health endpoint including all health checks that matches given tags.
    /// </summary>
    /// <param name="builder">The <see cref="IEndpointRouteBuilder"/> to add the health checks endpoint to.</param>
    /// <param name="route">The URL pattern of the health checks endpoint.</param>
    /// <param name="tags">A list of health check tags to include in the endpoint.</param>
    /// <returns></returns>
    public static IEndpointConventionBuilder AddHealthEndpointByTags(this IEndpointRouteBuilder builder, string route, string[] tags)
    {
        return builder.MapHealthChecks(route, new HealthCheckOptions
        {
            Predicate = check => check.Tags.Any(x => tags.Contains(x)),
            ResponseWriter = ResponseWriter.Write
        });
    }
}
