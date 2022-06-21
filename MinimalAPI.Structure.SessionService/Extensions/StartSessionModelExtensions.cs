using MinimalAPI.Structure.SessionService.DTOs;
using MinimalAPI.Structure.SessionService.Models;

namespace MinimalAPI.Structure.SessionService.Extensions;

internal static class StartSessionModelExtensions
{
    internal static HistorySessionDTO ToHistorySessionDTO(this StartSessionModel model, Guid sessionId)
    {
        if (model == null)
        {
            return null;
        }

        return new HistorySessionDTO
        {
            AccessDeviceValue = model.AccessDeviceValue,
            StartDate = model.StartDate,
            SessionId = sessionId,
        };
    }

    internal static ActiveSessionDTO ToActiveSessionDTO(this StartSessionModel model, Guid sessionId)
    {
        if (model == null)
        {
            return null;
        }

        return new ActiveSessionDTO
        {
            AccessDeviceValue = model.AccessDeviceValue,
            StartDate = model.StartDate,
            SessionId = sessionId,
        };
    }
}
