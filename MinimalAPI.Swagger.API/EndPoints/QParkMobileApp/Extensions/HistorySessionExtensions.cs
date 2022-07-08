using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Models;
using SessionServiceModels = MinimalAPI.Swagger.SessionService.Models;

namespace MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Extensions;

internal static class HistorySessionExtensions
{
    internal static List<HistorySession> ToWebApiModels(this List<SessionServiceModels.HistorySession> dtos)
    {
        return dtos?
            .Select(ToWebApiModel)
            .ToList() ?? new List<HistorySession>();
    }

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
            SessionType = dto.SessionType,
            CustomerId = dto.CustomerId,
        };
    }
}
