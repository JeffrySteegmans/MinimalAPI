namespace MinimalAPI.Structure.API.EndPoints.Sessions;

internal static class SessionsEndPointsNet7
{
    internal static RouteGroupBuilder MapSessionEndPoints(this IEndpointRouteBuilder routes)
    {
        ArgumentNullException.ThrowIfNull(routes);

        var group = routes.MapGroup("/sessionsnet7");

        group.MapGet("/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello from sessionAPIs in dotnet7.0!" });

        return group;
    }
}
