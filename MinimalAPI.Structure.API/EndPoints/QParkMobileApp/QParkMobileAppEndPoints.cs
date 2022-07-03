using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;
using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Models;
using MinimalAPI.Structure.SessionService;

using SessionServiceRequests = MinimalAPI.Structure.SessionService.Requests;

namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp;

internal class QParkMobileAppEndPoints
{
    private const string BASEPATH = "/mobile";

    internal void Initialize(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapGet($"{BASEPATH}/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello {name ?? "world"}!" });
        app.MapPost($"{BASEPATH}/StartSession", StartSession);
        app.MapPost($"{BASEPATH}/StopSession/{{sessionId}}", StopSession);
    }

    private async Task<ActiveSession> StartSession(HttpContext context, ISessionService sessionService, Requests.StartSessionRequest request)
    {
        var activeSession = await sessionService.StartSession(request.ToStartSessionRequest());

        return activeSession.ToWebApiModel();
    }

    private async Task<HistorySession> StopSession(HttpContext context, ISessionService sessionService, Guid sessionId)
    {
        var historySession = await sessionService.StopSession(new SessionServiceRequests.StopSessionRequest { SessionId = sessionId });

        return historySession.ToWebApiModel();
    }
}
