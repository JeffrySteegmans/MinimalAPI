namespace MinimalAPI.Swagger.SessionService.Models;

public class HistorySession
{
    public Guid SessionId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string AccessDeviceValue { get; set; } = string.Empty;

    public string SessionType { get; set; } = "RSTP";

    public Guid CustomerId { get; set; } = Guid.NewGuid();
}
