namespace MinimalAPI.Structure.SessionService.Requests;

public class StartSessionRequest
{
    public DateTime StartDate { get; set; }

    public string AccessDeviceValue { get; set; } = string.Empty;
}
