﻿namespace MinimalAPI.Structure.SessionService.Models;

public class HistorySession
{
    public Guid SessionId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string AccessDeviceValue { get; set; } = string.Empty;
}
