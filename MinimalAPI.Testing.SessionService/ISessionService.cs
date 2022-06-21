using MinimalAPI.Testing.SessionService.DTOs;
using MinimalAPI.Testing.SessionService.Models;

namespace MinimalAPI.Testing.SessionService;

public interface ISessionService
{
    Task<ActiveSessionDTO> StartSession(StartSessionModel model);

    Task<HistorySessionDTO?> StopSession(StopSessionModel model);
}
