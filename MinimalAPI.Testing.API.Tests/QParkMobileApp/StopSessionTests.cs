using MinimalAPI.Testing.API.EndPoints.Models;
using MinimalAPI.Testing.API.Tests.Fixtures;
using MinimalAPI.Testing.SessionService;
using Newtonsoft.Json;

namespace MinimalAPI.Testing.API.Tests.QParkMobileApp;

public class StopSessionTests : IClassFixture<ApiFixture>
{
    private readonly ApiFixture _fixture;

    public StopSessionTests(ApiFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GivenSessionExists_WhenStopSession_ThenShouldReturnHistorySession()
    {
        var sessionId = Guid.NewGuid();
        using var client = _fixture.CreateClient();

        using var response = await client.PostAsync($"/StopSession/{sessionId}", null);

        response.IsSuccessStatusCode.Should().BeTrue();
        response.Content.Should().NotBeNull();

        var content = await response.Content.ReadAsStringAsync();
        var historySession = JsonConvert.DeserializeObject<HistorySession>(content);

        using (new AssertionScope())
        {
            historySession.SessionId.Should().Be(sessionId);
            historySession.StartDate.Should().Be(FakeSessionService.SessionStartDate);
            historySession.EndDate.Should().Be(FakeSessionService.SessionEndDate);
            historySession.AccessDeviceValue.Should().Be(FakeSessionService.AccessDeviceValue);
        }
    }
}
