using MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Requests;
using SessionServiceRequests = MinimalAPI.Swagger.SessionService.Requests;

namespace MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Extensions;

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
