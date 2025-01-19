using FredrikLrsn.AspNetCore.HealthChecks;
using HealthChecks.Api.Checks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
    .AddHealthChecks()
    .AddPing("Ping")
    .AddCheck<ExceptionHealthCheck>("Exception")
    .AddCheck<RandomHealthCheck>("Random")
    .AddUrlGroup(new Uri("https://github.com"), name: "Github", tags: ["github", "url"])
    .AddUrlGroup(new Uri("https://microsoft.com"), name: "Microsoft", tags: ["microsoft", "url"]);

var app = builder.Build();

app.AddHealthEndpointByNames("/ping", ["Ping"]);
app.AddHealthEndpoint("/health");
app.AddHealthEndpointByTags("/health/urls", ["url"]);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
