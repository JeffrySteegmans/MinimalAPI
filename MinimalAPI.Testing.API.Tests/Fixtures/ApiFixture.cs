using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinimalAPI.Testing.SessionService;

namespace MinimalAPI.Testing.API.Tests.Fixtures;

public class ApiFixture : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Development");

        builder.ConfigureServices(services =>
        {
            services.AddSingleton<ISessionService, FakeSessionService>();
        });

        return base.CreateHost(builder);
    }
}
