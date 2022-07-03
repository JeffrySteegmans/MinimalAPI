using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Models;

namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;

internal static class ActiveSessionExtensions
{
    internal static ActiveSession ToWebApiModel(this SessionService.Models.ActiveSession dto)
    {
        if (dto == null)
        {
            return null!;
        }

        return new Models.ActiveSession
        {
            StartDate = dto.StartDate,
            AccessDeviceValue = dto.AccessDeviceValue,
            SessionId = dto.SessionId,
        };
    }
}
