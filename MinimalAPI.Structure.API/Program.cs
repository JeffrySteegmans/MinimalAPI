using Microsoft.Extensions.DependencyInjection;
using MinimalAPI.Structure.API.APIs;
using MinimalAPI.Structure.SessionService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISessionService, SessionService>();

var app = builder.Build();

var qParkMobileAppAPIs = new QParkMobileAppAPIs();
qParkMobileAppAPIs.Initialize(app);

app.Run();