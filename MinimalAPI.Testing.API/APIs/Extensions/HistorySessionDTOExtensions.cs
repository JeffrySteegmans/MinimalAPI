using MinimalAPI.Testing.SessionService.DTOs;
using MinimalAPI.Testing.API.APIs.Models;

namespace MinimalAPI.Testing.API.APIs.Extensions;

internal static class HistorySessionDTOExtensions
{
    internal static HistorySession ToWebApiModel(this HistorySessionDTO dto)
    {
        if (dto == null)
        {
            return null;
        }

        return new HistorySession
        {
            SessionId = dto.SessionId,
            AccessDeviceValue = dto.AccessDeviceValue,
            EndDate = dto.EndDate,
            StartDate = dto.StartDate,
        };
    }
}
