using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using MinimalAPI.Swagger.API;
using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp;
using MinimalAPI.Swagger.API.EndPoints.Sessions;
using MinimalAPI.Swagger.SessionService;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddApiVersioning()
    .AddApiExplorer(options =>
    {
        // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
        // note: the specified format code will format the version as "'v'major[.minor][-status]"
        options.GroupNameFormat = "'Minimal-API v'VVV";

        // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
        // can also be used to control the format of the API version in route templates
        options.SubstituteApiVersionInUrl = true;
    });
builder.Services.TryAddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services
    .AddAuthorization()
    .AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.TryAddSingleton<ISessionService, SessionService>();

var app = builder.Build();

var qParkMobileAppEndPoints = new QParkMobileAppEndPoints();
qParkMobileAppEndPoints.RegisterEndpoints(app);

var qParkMobileAppEndPointsV2 = new QParkMobileAppEndPointsV2();
qParkMobileAppEndPointsV2.RegisterEndpoints(app);

var sessionAPIs = new SessionsEndPoints();
sessionAPIs.RegisterEndpoints(app);

app
    .UseAuthorization()
    .UseSwagger()
    .UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        // build a swagger endpoint for each discovered API version
        foreach (var description in descriptions)
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName;
            options.SwaggerEndpoint(url, name);
        }
    });

app.Run();