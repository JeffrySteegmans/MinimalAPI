using MinimalAPI.Swagger.SessionService;
using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Extensions;
using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Models;
using SessionServiceRequests = MinimalAPI.Swagger.SessionService.Requests;
using Microsoft.AspNetCore.Authorization;

namespace MinimalAPI.Swagger.API.EndPoints.QParkMobileApp;

internal class QParkMobileAppEndPoints
{
    private const string BASEPATH = "/mobile";

    internal void Initialize(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);
        
        app.MapGet($"{BASEPATH}/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello {name ?? "world"}!" });
        app.MapGet($"{BASEPATH}/Foo", [Authorize](HttpContext context) => new { message = $"Hello foo!" });
        app.MapPost($"{BASEPATH}/Bar", Bar);
        app.MapPost($"{BASEPATH}/StartSession", StartSession);
        app.MapPost($"{BASEPATH}/StopSession/{{sessionId}}", StopSession);
    }

    [Authorize]
    private Task<string> Bar(HttpContext context, [FromQuery] string? name)
    {
        return Task.FromResult($"Hello {name ?? "bar"}!");
    }

    private async Task<ActiveSession> StartSession(HttpContext context, ISessionService sessionService, Requests.StartSessionRequest request)
    {
        var activeSession = await sessionService.StartSession(request.ToStartSessionRequest());

        return activeSession.ToWebApiModel();
    }

    private async Task<HistorySession> StopSession(HttpContext context, ISessionService sessionService, Guid sessionId)
    {
        var request = new SessionServiceRequests.StopSessionRequest(sessionId);
        var historySession = await sessionService.StopSession(request);

        return historySession.ToWebApiModel();
    }
}
