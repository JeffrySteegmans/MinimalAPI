using MinimalAPI.Testing.SessionService.DTOs;
using MinimalAPI.Testing.SessionService.Models;

namespace MinimalAPI.Testing.SessionService;

public class FakeSessionService : ISessionService
{
    public static readonly DateTime SessionStartDate = new DateTime(2021, 06, 01, 08, 05, 00);
    public static readonly DateTime SessionEndDate = SessionStartDate.AddDays(1);
    public static readonly string AccessDeviceValue = "1ABC123";

    public Task<ActiveSessionDTO> StartSession(StartSessionModel model)
    {
        throw new NotImplementedException();
    }

    public Task<HistorySessionDTO> StopSession(StopSessionModel model)
    {
        var historySession = new HistorySessionDTO
        {
            AccessDeviceValue = AccessDeviceValue,
            SessionId = model.SessionId,
            StartDate = SessionStartDate,
            EndDate = SessionEndDate,
        };

        return Task.FromResult(historySession);
    }
}
