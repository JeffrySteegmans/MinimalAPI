using SessionServiceModels = MinimalAPI.Testing.SessionService.Models;
using MinimalAPI.Testing.API.EndPoints.Models;

namespace MinimalAPI.Testing.API.EndPoints.Extensions;

internal static class HistorySessionExtensions
{
    internal static HistorySession ToWebApiModel(this SessionServiceModels.HistorySession model)
    {
        if (model == null)
        {
            return null!;
        }

        return new HistorySession
        {
            SessionId = model.SessionId,
            AccessDeviceValue = model.AccessDeviceValue,
            EndDate = model.EndDate,
            StartDate = model.StartDate,
        };
    }
}
