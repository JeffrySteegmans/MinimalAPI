﻿using MinimalAPI.Structure.API.APIs.Extensions;
using MinimalAPI.Structure.API.APIs.Models;
using MinimalAPI.Structure.API.APIs.Requests;
using MinimalAPI.Structure.SessionService;
using MinimalAPI.Structure.SessionService.Models;

namespace MinimalAPI.Structure.API.APIs;

internal class QParkMobileAppAPIs
{
    internal void Initialize(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapGet("/Hello", (HttpContext context, [FromQuery]string? name) => new { message = $"Hello {name ?? "world"}!" });
        app.MapPost("/StartSession", StartSession);
        app.MapPost("/StopSession/{sessionId}", StopSession);
    }

    private async Task<ActiveSession> StartSession(HttpContext context, ISessionService sessionService, StartSessionRequest request)
    {
        var activeSessionDTO = await sessionService.StartSession(request.ToStartSessionModel());

        return activeSessionDTO.ToWebApiModel();
    }

    private async Task<HistorySession> StopSession(HttpContext context, ISessionService sessionService, Guid sessionId)
    {
        var historySessionDTO = await sessionService.StopSession(new StopSessionModel { SessionId = sessionId });

        return historySessionDTO.ToWebApiModel();
    }
}