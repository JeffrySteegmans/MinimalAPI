using MinimalAPI.Structure.API.APIs.Models;
using MinimalAPI.Structure.SessionService.DTOs;

namespace MinimalAPI.Structure.API.APIs.Extensions;

internal static class ActiveSessionDTOExtensions
{
    internal static ActiveSession ToWebApiModel(this ActiveSessionDTO dto)
    {
        if (dto == null)
        {
            return null;
        }

        return new ActiveSession
        {
            StartDate = dto.StartDate,
            AccessDeviceValue = dto.AccessDeviceValue,
            SessionId = dto.SessionId,
        };
    }
}
