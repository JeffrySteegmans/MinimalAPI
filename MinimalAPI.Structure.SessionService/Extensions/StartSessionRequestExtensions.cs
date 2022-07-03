using MinimalAPI.Structure.SessionService.Models;
using MinimalAPI.Structure.SessionService.Requests;

namespace MinimalAPI.Structure.SessionService.Extensions;

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
