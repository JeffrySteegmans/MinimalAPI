namespace MinimalAPI.Structure.API.APIs;

internal class SessionAPIs
{
    private const string BASEPATH = "/session";

    internal void Initialize(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapGet($"{BASEPATH}/Hello", (HttpContext context, [FromQuery]string? name) => new { message = $"Hello from sessionAPIs!" });
    }
}
