using MinimalAPI.Swagger.SessionService.Models;
using MinimalAPI.Swagger.SessionService.Requests;

namespace MinimalAPI.Swagger.SessionService.Extensions;

internal static class StartSessionRequestExtensions
{
    internal static HistorySession ToHistorySessionDomainModel(this StartSessionRequest model, Guid sessionId)
    {
        if (model == null)
        {
            return null!;
        }

        return new HistorySession
        {
            AccessDeviceValue = model.AccessDeviceValue,
            StartDate = model.StartDate,
            SessionId = sessionId,
        };
    }

    internal static ActiveSession ToActiveSessionDomainModel(this StartSessionRequest model, Guid sessionId)
    {
        if (model == null)
        {
            return null!;
        }

        return new ActiveSession
        {
            AccessDeviceValue = model.AccessDeviceValue,
            StartDate = model.StartDate,
            SessionId = sessionId,
        };
    }
}
