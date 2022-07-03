using Microsoft.Extensions.DependencyInjection;
using MinimalAPI.Testing.API.EndPoints;
using MinimalAPI.Testing.SessionService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISessionService, SessionService>();

var app = builder.Build();

var qParkMobileAppAPIs = new QParkMobileAppAPIs();
qParkMobileAppAPIs.Initialize(app);

app.Run();

public partial class Program { }