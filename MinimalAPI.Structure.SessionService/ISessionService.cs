using MinimalAPI.Structure.SessionService.DTOs;
using MinimalAPI.Structure.SessionService.Models;

namespace MinimalAPI.Structure.SessionService;

public interface ISessionService
{
    Task<ActiveSessionDTO> StartSession(StartSessionModel model);

    Task<HistorySessionDTO> StopSession(StopSessionModel model);
}
