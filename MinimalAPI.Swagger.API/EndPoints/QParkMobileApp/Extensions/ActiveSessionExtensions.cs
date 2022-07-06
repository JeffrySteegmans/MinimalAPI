using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Models;
using SessionServiceModels = MinimalAPI.Swagger.SessionService.Models;

namespace MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Extensions;

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
