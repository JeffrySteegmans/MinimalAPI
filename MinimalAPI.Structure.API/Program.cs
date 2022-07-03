using Microsoft.Extensions.DependencyInjection.Extensions;
using MinimalAPI.Structure.API.APIs;
using MinimalAPI.Structure.SessionService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<ISessionService, SessionService>();

var app = builder.Build();

var qParkMobileAppAPIs = new QParkMobileAppAPIs();
qParkMobileAppAPIs.Initialize(app);

var sessionAPIs = new SessionAPIs();
sessionAPIs.Initialize(app);

app.Run();