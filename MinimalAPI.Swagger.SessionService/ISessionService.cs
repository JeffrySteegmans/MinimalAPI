using MinimalAPI.Swagger.SessionService.Models;
using MinimalAPI.Swagger.SessionService.Requests;

namespace MinimalAPI.Swagger.SessionService;

public interface ISessionService
{
    Task<ActiveSession> StartSession(StartSessionRequest model);

    Task<HistorySession> StopSession(StopSessionRequest model);
}
