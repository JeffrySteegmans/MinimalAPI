namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Extensions;

internal static class StartSessionRequestExtensions
{
    internal static SessionService.Requests.StartSessionRequest ToStartSessionRequest(this Requests.StartSessionRequest request)
    {
        if (request == null)
        {
            return null!;
        }

        return new SessionService.Requests.StartSessionRequest
        {
            AccessDeviceValue = request.AccessDeviceValue,
            StartDate = request.StartDate,
        };
    }
}
