using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Requests;
using MinimalAPI.Structure.SessionService.Models;

namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;

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
