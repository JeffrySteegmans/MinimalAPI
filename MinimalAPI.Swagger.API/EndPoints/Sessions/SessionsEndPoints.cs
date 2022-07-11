using Asp.Versioning.Conventions;

namespace MinimalAPI.Swagger.API.EndPoints.Sessions;

internal class SessionsEndPoints
{
    private const string VERSIONSETNAME = "Parking sessions";
    private const string BASEPATH = "/sessions";
    private const double VERSION = 1.0;

    internal void RegisterEndpoints(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var SessionVersionSet = app
            .NewApiVersionSet(VERSIONSETNAME)
            .Build();

        app.MapGet($"{BASEPATH}/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello from sessionAPIs!" })
            .Produces(404)
            .WithApiVersionSet(SessionVersionSet)
            .HasApiVersion(VERSION);
        app.MapGet($"{BASEPATH}/ActiveSessions", GetActiveSessions)
            .Produces<string>(200)
            .Produces(404)
            .WithApiVersionSet(SessionVersionSet)
            .HasApiVersion(VERSION);
    }

    internal Task<string> GetActiveSessions (HttpContext context, [FromQuery] string? countryCode)
    {
        return Task.FromResult($"ActiveSessions for country {countryCode}");
    }
}
