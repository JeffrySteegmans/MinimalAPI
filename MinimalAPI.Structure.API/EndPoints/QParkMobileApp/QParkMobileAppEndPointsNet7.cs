using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;
using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Models;
using MinimalAPI.Structure.SessionService;

using SessionServiceRequests = MinimalAPI.Structure.SessionService.Requests;

namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp;

internal static class QParkMobileAppEndPointsNet7
{
    internal static RouteGroupBuilder MapQParkMobileAppEndPoints(this IEndpointRouteBuilder routes)
    {
        ArgumentNullException.ThrowIfNull(routes);

        var group = routes.MapGroup("/mobilenet7");

        group.MapGet("/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello {name ?? "world"}!" });
        group.MapPost("/StartSession", StartSession);
        group.MapPost("/StopSession/{sessionId}", StopSession);

        return group;
    }

    private static async Task<ActiveSession> StartSession(HttpContext context, ISessionService sessionService, Requests.StartSessionRequest request)
    {
        var activeSession = await sessionService.StartSession(request.ToStartSessionRequest());

        return activeSession.ToWebApiModel();
    }

    private static async Task<HistorySession> StopSession(HttpContext context, ISessionService sessionService, Guid sessionId)
    {
        var request = new SessionServiceRequests.StopSessionRequest(sessionId);
        var historySession = await sessionService.StopSession(request);

        return historySession.ToWebApiModel();
    }
}
