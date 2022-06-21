using MinimalAPI.Testing.SessionService.DTOs;
using MinimalAPI.Testing.SessionService.Models;

namespace MinimalAPI.Testing.SessionService.Extensions;

internal static class StartSessionModelExtensions
{
    internal static HistorySessionDTO ToHistorySessionDTO(this StartSessionModel model, Guid sessionId)
    {
        var (startDate, accessDeviceValue) = model;

        return new HistorySessionDTO
        {
            AccessDeviceValue = accessDeviceValue,
            StartDate = startDate,
            SessionId = sessionId,
        };
    }

    internal static ActiveSessionDTO ToActiveSessionDTO(this StartSessionModel model, Guid sessionId)
    {
        var (startDate, accessDeviceValue) = model;

        return new ActiveSessionDTO
        {
            AccessDeviceValue = accessDeviceValue,
            StartDate = startDate,
            SessionId = sessionId,
        };
    }
}
