using MinimalAPI.Testing.SessionService.Extensions;
using MinimalAPI.Testing.SessionService.Models;
using MinimalAPI.Testing.SessionService.Requests;

namespace MinimalAPI.Testing.SessionService;

public class SessionService : ISessionService
{
    private readonly List<HistorySession> _sessions = new();

    public Task<ActiveSession> StartSession(StartSessionRequest model)
    {
        var sessionId = Guid.NewGuid();

        _sessions.Add(model.ToHistorySession(sessionId)!);

        return Task.FromResult(model.ToActiveSession(sessionId)!);
    }

    public Task<HistorySession?> StopSession(StopSessionRequest model)
    {
        var sessionId = model.SessionId;
        var historySession = _sessions.SingleOrDefault(x => x.SessionId == sessionId);

        if (historySession == null)
        {
            return Task.FromResult<HistorySession?>(null);
        }

        var updatedHistorySession = historySession with { EndDate = DateTime.UtcNow };
        
        _sessions.Remove(historySession);
        _sessions.Add(updatedHistorySession);

        return Task.FromResult<HistorySession?>(updatedHistorySession);
    }
}
