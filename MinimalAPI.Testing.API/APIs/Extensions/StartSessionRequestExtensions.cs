using MinimalAPI.Testing.SessionService.Models;
using MinimalAPI.Testing.API.APIs.Requests;

namespace MinimalAPI.Testing.API.APIs.Extensions;

internal static class StartSessionRequestExtensions
{
    internal static StartSessionModel ToStartSessionModel(this StartSessionRequest request)
    {
        if (request == null)
        {
            return null;
        }

        return new StartSessionModel
        {
            AccessDeviceValue = request.AccessDeviceValue,
            StartDate = request.StartDate,
        };
    }
}
