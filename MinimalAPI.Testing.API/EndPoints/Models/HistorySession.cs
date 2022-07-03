﻿namespace MinimalAPI.Testing.API.EndPoints.Models;

public record HistorySession
{
    public Guid SessionId { get; init; }

    public DateTime StartDate { get; init; }

    public DateTime? EndDate { get; init; }

    public string AccessDeviceValue { get; init; } = string.Empty;
}
