namespace MinimalAPI.Swagger.API.EndPoints.Sessions;

internal class SessionsEndPoints
{
    private const string BASEPATH = "/sessions";

    internal void Initialize(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapGet($"{BASEPATH}/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello from sessionAPIs!" });
        app.MapGet($"{BASEPATH}/ActiveSessions", GetActiveSessions);
    }

    internal Task<string> GetActiveSessions (HttpContext context, [FromQuery] string? countryCode)
    {
        return Task.FromResult($"ActiveSessions for country {countryCode}");
    }
}
