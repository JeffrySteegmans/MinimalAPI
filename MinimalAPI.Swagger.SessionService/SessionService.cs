using MinimalAPI.Swagger.SessionService.Extensions;
using MinimalAPI.Swagger.SessionService.Models;
using MinimalAPI.Swagger.SessionService.Requests;

namespace MinimalAPI.Swagger.SessionService;

public class SessionService : ISessionService
{
    private readonly List<HistorySession> _sessions = new List<HistorySession>();

    public Task<List<HistorySession>> GetSessionsForCustomerByType(GetSessionsForCustomerByTypeRequest model)
    {
        if (_sessions.Count == 0)
        {
            AddTestSessions(model.customerId);
        }

        var sessions = _sessions
            .Where(x => x.CustomerId.Equals(model.customerId) &&
                        x.SessionType.Equals(model.sessionType))
            .ToList();

        return Task.FromResult(sessions);
    }

    public Task<ActiveSession> StartSession(StartSessionRequest model)
    {
        var sessionId = Guid.NewGuid();

        _sessions.Add(model.ToHistorySessionDomainModel(sessionId));

        return Task.FromResult(model.ToActiveSessionDomainModel(sessionId));
    }

    public Task<HistorySession> StopSession(StopSessionRequest model)
    {
        var historySession = _sessions.SingleOrDefault(x => x.SessionId == model.SessionId);

        if (historySession == null)
        {
            return Task.FromResult<HistorySession>(null!);
        }

        historySession.EndDate = DateTime.UtcNow;

        return Task.FromResult(historySession);
    }

    private void AddTestSessions(Guid? customerId = null)
    {
        _sessions.Add(new HistorySession { 
            SessionId = Guid.NewGuid(),
            AccessDeviceValue = "1ABC123",
            StartDate = DateTime.UtcNow.AddDays(-1),
            EndDate = DateTime.UtcNow.AddHours(-5),
            SessionType = "RSTP",
            CustomerId = customerId ?? Guid.NewGuid(),
        });;
        _sessions.Add(new HistorySession { 
            SessionId = Guid.NewGuid(),
            AccessDeviceValue = "1ABC456",
            StartDate = DateTime.UtcNow.AddDays(-5),
            EndDate = DateTime.UtcNow.AddDays(-3),
            SessionType = "MSTP",
            CustomerId = customerId ?? Guid.NewGuid(),
        });
        _sessions.Add(new HistorySession { 
            SessionId = Guid.NewGuid(),
            AccessDeviceValue = "1ABC789",
            StartDate = DateTime.UtcNow.AddDays(-20),
            EndDate = DateTime.UtcNow.AddDays(-19),
            SessionType = "SeasonTicket",
            CustomerId = customerId ?? Guid.NewGuid(),
        });
    }
}
