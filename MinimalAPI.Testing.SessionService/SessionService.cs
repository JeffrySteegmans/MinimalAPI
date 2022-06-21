using MinimalAPI.Testing.SessionService.DTOs;
using MinimalAPI.Testing.SessionService.Extensions;
using MinimalAPI.Testing.SessionService.Models;

namespace MinimalAPI.Testing.SessionService;

public class SessionService : ISessionService
{
    private readonly List<HistorySessionDTO> _sessions = new();

    public Task<ActiveSessionDTO> StartSession(StartSessionModel model)
    {
        var sessionId = Guid.NewGuid();

        _sessions.Add(model.ToHistorySessionDTO(sessionId));

        return Task.FromResult(model.ToActiveSessionDTO(sessionId));
    }

    public Task<HistorySessionDTO?> StopSession(StopSessionModel model)
    {
        var sessionId = model.SessionId;
        var historySessionDTO = _sessions.SingleOrDefault(x => x.SessionId == sessionId);

        if (historySessionDTO == null)
        {
            return Task.FromResult<HistorySessionDTO?>(null);
        }

        historySessionDTO.EndDate = DateTime.UtcNow;

        return Task.FromResult<HistorySessionDTO?>(historySessionDTO);
    }
}
