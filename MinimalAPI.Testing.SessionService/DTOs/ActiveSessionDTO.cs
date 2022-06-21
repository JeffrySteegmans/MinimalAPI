namespace MinimalAPI.Testing.SessionService.DTOs;

public class ActiveSessionDTO
{
    public Guid SessionId { get; set; }

    public DateTime StartDate { get; set; }

    public string AccessDeviceValue { get; set; } = string.Empty;
}