namespace MinimalAPI.Structure.API.EndPoints.Sessions;

internal class SessionsEndPoints
{
    private const string BASEPATH = "/sessions";

    internal void Initialize(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapGet($"{BASEPATH}/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello from sessionAPIs!" });
    }
}
