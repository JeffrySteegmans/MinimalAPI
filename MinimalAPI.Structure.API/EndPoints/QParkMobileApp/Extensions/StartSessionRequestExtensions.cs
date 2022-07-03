using MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Requests;
using SessionServiceRequests = MinimalAPI.Structure.SessionService.Requests;

namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;

internal static class StartSessionRequestExtensions
{
    internal static SessionServiceRequests.StartSessionRequest ToStartSessionRequest(this StartSessionRequest request)
    {
        if (request == null)
        {
            return null!;
        }

        return new SessionServiceRequests.StartSessionRequest(request.StartDate, request.AccessDeviceValue);
    }
}
