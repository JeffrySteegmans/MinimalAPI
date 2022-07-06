namespace MinimalAPI.Swagger.SessionService.Models;

public class ActiveSession
{
    public Guid SessionId { get; set; }

    public DateTime StartDate { get; set; }

    public string AccessDeviceValue { get; set; } = string.Empty;
}
