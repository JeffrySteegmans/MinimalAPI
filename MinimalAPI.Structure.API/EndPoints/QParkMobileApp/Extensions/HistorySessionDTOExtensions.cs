using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Models;
using MinimalAPI.Structure.SessionService.DTOs;

namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;

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
