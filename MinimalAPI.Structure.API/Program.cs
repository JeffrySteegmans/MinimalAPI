using Microsoft.Extensions.DependencyInjection.Extensions;
using MinimalAPI.Structure.API.EndPoints.QParkMobileApp;
using MinimalAPI.Structure.API.EndPoints.Sessions;
using MinimalAPI.Structure.SessionService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<ISessionService, SessionService>();

var app = builder.Build();

var qParkMobileAppAPIs = new QParkMobileAppEndPoints();
qParkMobileAppAPIs.Initialize(app);

var sessionAPIs = new SessionsEndPoints();
sessionAPIs.Initialize(app);

app.Run();