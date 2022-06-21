using MinimalAPI.Structure.SessionService.DTOs;
using MinimalAPI.Structure.SessionService.Extensions;
using MinimalAPI.Structure.SessionService.Models;

namespace MinimalAPI.Structure.SessionService;

public class SessionService : ISessionService
{
    private readonly List<HistorySessionDTO> _sessions = new List<HistorySessionDTO>();

    public Task<ActiveSessionDTO> StartSession(StartSessionModel model)
    {
        var sessionId = Guid.NewGuid();

        _sessions.Add(model.ToHistorySessionDTO(sessionId));

        return Task.FromResult(model.ToActiveSessionDTO(sessionId));
    }

    public Task<HistorySessionDTO> StopSession(StopSessionModel model)
    {
        var historySessionDTO = _sessions.SingleOrDefault(x => x.SessionId == model.SessionId);

        if (historySessionDTO == null)
        {
            return Task.FromResult<HistorySessionDTO>(null);
        }

        historySessionDTO.EndDate = DateTime.UtcNow;

        return Task.FromResult(historySessionDTO);
    }
}
