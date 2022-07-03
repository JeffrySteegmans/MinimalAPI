using MinimalAPI.Structure.SessionService.Models;
using MinimalAPI.Structure.SessionService.Requests;

namespace MinimalAPI.Structure.SessionService;

public interface ISessionService
{
    Task<ActiveSession> StartSession(StartSessionRequest model);

    Task<HistorySession> StopSession(StopSessionRequest model);
}
