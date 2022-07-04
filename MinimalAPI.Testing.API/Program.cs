using Microsoft.Extensions.DependencyInjection;
using MinimalAPI.Testing.API.EndPoints.QParkMobileApp;
using MinimalAPI.Testing.API.EndPoints.Sessions;
using MinimalAPI.Testing.SessionService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISessionService, SessionService>();

var app = builder.Build();

var qParkMobileAppAPIs = new QParkMobileAppAPIs();
qParkMobileAppAPIs.Initialize(app);

var sessionAPIs = new SessionsEndPoints();
sessionAPIs.Initialize(app);

app.Run();

public partial class WebApi { }