using MinimalAPI.Testing.SessionService.Models;
using MinimalAPI.Testing.SessionService.Requests;

namespace MinimalAPI.Testing.SessionService;

public class FakeSessionService : ISessionService
{
    public static readonly DateTime SessionStartDate = new DateTime(2021, 06, 01, 08, 05, 00);
    public static readonly DateTime SessionEndDate = SessionStartDate.AddDays(1);
    public static readonly string AccessDeviceValue = "1ABC123";

    public Task<ActiveSession> StartSession(StartSessionRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<HistorySession?> StopSession(StopSessionRequest model)
    {
        var historySession = new HistorySession
        {
            AccessDeviceValue = AccessDeviceValue,
            SessionId = model.SessionId,
            StartDate = SessionStartDate,
            EndDate = SessionEndDate,
        };

        return Task.FromResult(historySession)!;
    }
}
