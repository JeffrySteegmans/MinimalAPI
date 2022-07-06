using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MinimalAPI.Swagger.API;
using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp;
using MinimalAPI.Swagger.API.EndPoints.Sessions;
using MinimalAPI.Swagger.SessionService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>
                ("BasicAuthentication", null);
builder.Services.AddAuthorization();

builder.Services.TryAddSingleton<ISessionService, SessionService>();

var app = builder.Build();

app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var qParkMobileAppAPIs = new QParkMobileAppEndPoints();
qParkMobileAppAPIs.Initialize(app);

var sessionAPIs = new SessionsEndPoints();
sessionAPIs.Initialize(app);

app.Run();