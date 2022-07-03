using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Models;
using SessionServiceModels = MinimalAPI.Structure.SessionService.Models;

namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;

internal static class HistorySessionExtensions
{
    internal static HistorySession ToWebApiModel(this SessionServiceModels.HistorySession dto)
    {
        if (dto == null)
        {
            return null!;
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
