using SessionServiceModels = MinimalAPI.Testing.SessionService.Models;
using MinimalAPI.Testing.API.EndPoints.Models;

namespace MinimalAPI.Testing.API.EndPoints.Extensions;

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
