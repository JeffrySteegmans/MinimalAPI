using MinimalAPI.Testing.SessionService.Models;
using MinimalAPI.Testing.SessionService.Requests;

namespace MinimalAPI.Testing.SessionService;

public interface ISessionService
{
    Task<ActiveSession> StartSession(StartSessionRequest model);

    Task<HistorySession?> StopSession(StopSessionRequest model);
}
