﻿namespace MinimalAPI.Swagger.API.EndPoints.QParkMobileApp.Models;

public record ActiveSession
{
    public Guid SessionId { get; init; }

    public DateTime StartDate { get; init; }

    public string AccessDeviceValue { get; init; } = string.Empty;
}
