using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Models;
using SessionServiceModels = MinimalAPI.Structure.SessionService.Models;

namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;

internal static class ActiveSessionExtensions
{
    internal static ActiveSession ToWebApiModel(this SessionServiceModels.ActiveSession model)
    {
        if (model == null)
        {
            return null!;
        }

        return new ActiveSession
        {
            StartDate = model.StartDate,
            AccessDeviceValue = model.AccessDeviceValue,
            SessionId = model.SessionId,
        };
    }
}
