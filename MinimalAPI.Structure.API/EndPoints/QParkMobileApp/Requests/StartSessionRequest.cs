namespace MinimalAPI.Structure.API.EndPoints.QParkMobileApp.Requests;

public class StartSessionRequest
{
    public DateTime StartDate { get; set; }

    public string AccessDeviceValue { get; set; } = string.Empty;
}
