## FredrikLrsn.AspNetCore.HealthChecks

A component for standardazing the response of ASP.NET Core health checks.

# How to use

1. Register health checks according to documentation for [Health checks in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-9.0). This can include your own custom health checks, or e.g. health checks from [Xabaril/AspNetCore.Diagnostics.HealthChecks](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks).

```C#
builder.Services
    .AddHealthChecks()
    .AddPing("Ping")
    .AddCheck<ExceptionHealthCheck>("Exception")
    .AddCheck<RandomHealthCheck>("Random")
    .AddUrlGroup(new Uri("https://github.com"), name: "Github", tags: ["github", "url"])
    .AddUrlGroup(new Uri("https://microsoft.com"), name: "Microsoft", tags: ["microsoft", "url"]);
```

2. Add endpoints using the registered health checks.

```C#
app.AddHealthEndpointByNames("/ping", ["Ping"]);
app.AddHealthEndpoint("/health");
app.AddHealthEndpointByTags("/health/url", ["url"]);
```

# How to test

Run the sample api project.

# References

- https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-9.0
- https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks