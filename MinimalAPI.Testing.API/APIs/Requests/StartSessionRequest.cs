﻿namespace MinimalAPI.Testing.API.APIs.Requests;

public class StartSessionRequest
{
    public DateTime StartDate { get; set; }

    public string AccessDeviceValue { get; set; } = string.Empty;
}