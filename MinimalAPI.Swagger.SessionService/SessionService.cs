using MinimalAPI.Swagger.SessionService.Extensions;
using MinimalAPI.Swagger.SessionService.Models;
using MinimalAPI.Swagger.SessionService.Requests;

namespace MinimalAPI.Swagger.SessionService;

public class SessionService : ISessionService
{
    private readonly List<HistorySession> _sessions = new List<HistorySession>();

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
            return Task.FromResult<HistorySession>(null);
        }

        historySession.EndDate = DateTime.UtcNow;

        return Task.FromResult(historySession);
    }
}
