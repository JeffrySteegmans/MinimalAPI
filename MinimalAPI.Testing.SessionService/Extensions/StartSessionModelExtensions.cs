using MinimalAPI.Testing.SessionService.Models;
using MinimalAPI.Testing.SessionService.Requests;

namespace MinimalAPI.Testing.SessionService.Extensions;

internal static class StartSessionModelExtensions
{
    internal static HistorySession? ToHistorySession(this StartSessionRequest request, Guid sessionId)
    {
        if (request is null)
        {
            return null!;
        }

        var (startDate, accessDeviceValue) = request;

        return new HistorySession
        {
            AccessDeviceValue = accessDeviceValue,
            StartDate = startDate,
            SessionId = sessionId,
        };
    }

    internal static ActiveSession? ToActiveSession(this StartSessionRequest request, Guid sessionId)
    {
        if (request is null)
        {
            return null!;
        }

        var (startDate, accessDeviceValue) = request;

        return new ActiveSession
        {
            AccessDeviceValue = accessDeviceValue,
            StartDate = startDate,
            SessionId = sessionId,
        };
    }
}
