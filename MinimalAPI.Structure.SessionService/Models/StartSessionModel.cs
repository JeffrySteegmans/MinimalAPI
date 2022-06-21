namespace MinimalAPI.Structure.SessionService.Models;

public class StartSessionModel
{
    public DateTime StartDate { get; set; }

    public string AccessDeviceValue { get; set; } = string.Empty;
}
