namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;

internal static class HistorySessionExtensions
{
    internal static Models.HistorySession ToWebApiModel(this SessionService.Models.HistorySession dto)
    {
        if (dto == null)
        {
            return null!;
        }

        return new Models.HistorySession
        {
            SessionId = dto.SessionId,
            AccessDeviceValue = dto.AccessDeviceValue,
            EndDate = dto.EndDate,
            StartDate = dto.StartDate,
        };
    }
}
