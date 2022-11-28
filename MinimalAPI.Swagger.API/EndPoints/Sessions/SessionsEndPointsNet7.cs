using Asp.Versioning.Conventions;

namespace MinimalAPI.Swagger.API.EndPoints.Sessions;

internal static class SessionsEndPointsNet7
{
    private const string VERSIONSETNAME = "Parking sessions";
    private const double VERSION = 1.0;

    internal static RouteGroupBuilder MapSessionEndPoints(this IEndpointRouteBuilder routes)
    {
        ArgumentNullException.ThrowIfNull(routes);

        var group = routes.MapGroup("/sessionsnet7");

        var SessionVersionSet = group
            .NewApiVersionSet(VERSIONSETNAME)
            .Build();

        group.MapGet($"/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello from sessionAPIs!" })
            .Produces(404)
            .WithApiVersionSet(SessionVersionSet)
            .HasApiVersion(VERSION);
        group.MapGet($"/ActiveSessions", GetActiveSessions)
            .Produces<string>(200)
            .Produces(404)
            .WithApiVersionSet(SessionVersionSet)
            .HasApiVersion(VERSION);

        return group;
    }

    internal static Task<string> GetActiveSessions(HttpContext context, [FromQuery] string? countryCode)
    {
        return Task.FromResult($"ActiveSessions for country {countryCode}");
    }
}
