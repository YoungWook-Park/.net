namespace Refact.PLC.DAQ.Domain.Options;

/// <summary>
/// Application configuration options bound from appsettings.json.
/// </summary>
public class AppOptions
{
    public const string SectionName = "App";

    public string Name { get; set; } = "Refact.PLC.DAQ";
    public string Version { get; set; } = "1.0.0";
}
