﻿using Asp.Versioning.Conventions;
using MinimalAPI.Swagger.SessionService;
using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Extensions;
using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Models;
using SessionServiceRequests = MinimalAPI.Swagger.SessionService.Requests;

namespace MinimalAPI.Swagger.API.EndPoints.QParkMobileApp;

internal class QParkMobileAppEndPoints
{
    private const string VERSIONSETNAME = "Q-Park mobile app";
    private const string BASEPATH = "/mobile";
    private const double VERSION = 1.0;

    internal void RegisterEndpoints(WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        var qparkMobileAppVersionSet = app
            .NewApiVersionSet(VERSIONSETNAME)
            .Build();

        app.MapGet($"{BASEPATH}/Hello", (HttpContext context, [FromQuery] string? name) => new { message = $"Hello {name ?? "world"}!" })
            .Produces(404)
            .WithApiVersionSet(qparkMobileAppVersionSet)
            .HasApiVersion(VERSION);
        app.MapGet($"{BASEPATH}/Foo", [Authorize] (HttpContext context) => new { message = $"Hello foo!" })
            .Produces(404)
            .WithApiVersionSet(qparkMobileAppVersionSet)
            .HasApiVersion(VERSION);
        app.MapPost($"{BASEPATH}/Bar", Bar)
            .Produces<string>(200)
            .Produces(404)
            .WithApiVersionSet(qparkMobileAppVersionSet)
            .HasApiVersion(VERSION);
        app.MapPost($"{BASEPATH}/StartSession", StartSession)
            .Produces<ActiveSession>(200)
            .Produces(404)
            .WithApiVersionSet(qparkMobileAppVersionSet)
            .HasApiVersion(VERSION);
        app.MapPost($"{BASEPATH}/StopSession/{{sessionId}}", StopSession)
            .Produces<HistorySession>(200)
            .Produces(404)
            .WithApiVersionSet(qparkMobileAppVersionSet)
            .HasApiVersion(VERSION);
        app.MapGet($"{BASEPATH}/customer/{{customerId}}/Session/{{sessionType}}", GetSessionsForCustomer)
            .Produces<HistorySession>(200)
            .Produces(404)
            .WithApiVersionSet(qparkMobileAppVersionSet)
            .HasApiVersion(VERSION);
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

    private async Task<List<HistorySession>> GetSessionsForCustomer(HttpContext context, ISessionService sessionService, Guid customerId, string type)
    {
        var request = new SessionServiceRequests.GetSessionsForCustomerByTypeRequest(customerId, type);
        var historySessions = await sessionService.GetSessionsForCustomerByType(request);

        return historySessions.ToWebApiModels();
    }
}
