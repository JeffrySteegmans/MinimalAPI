using MinimalAPI.Testing.API.EndPoints.Extensions;
using MinimalAPI.Testing.API.EndPoints.Models;
using MinimalAPI.Testing.API.EndPoints.Requests;
using MinimalAPI.Testing.SessionService;
using SessionServiceRequests = MinimalAPI.Testing.SessionService.Requests;

namespace MinimalAPI.Testing.API.EndPoints.QParkMobileApp;

internal class QParkMobileAppAPIs
{
    internal void Initialize(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapGet("/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello {name ?? "world"}!" });
        app.MapPost("/StartSession", StartSession);
        app.MapPost("/StopSession/{sessionId}", StopSession);
    }

    private async Task<ActiveSession> StartSession(HttpContext context, ISessionService sessionService, StartSessionRequest request)
    {
        var activeSession = await sessionService.StartSession(request.ToStartSessionRequest());

        return activeSession.ToWebApiModel();
    }

    private async Task<HistorySession?> StopSession(HttpContext context, ISessionService sessionService, Guid sessionId)
    {
        var historySession = await sessionService.StopSession(new SessionServiceRequests.StopSessionRequest(sessionId));

        if (historySession is null)
        {
            return null!;
        }

        return historySession!.ToWebApiModel();
    }
}
