using MinimalAPI.Testing.API.EndPoints.Requests;
using SessionServiceRequests = MinimalAPI.Testing.SessionService.Requests;

namespace MinimalAPI.Testing.API.EndPoints.Extensions;

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
