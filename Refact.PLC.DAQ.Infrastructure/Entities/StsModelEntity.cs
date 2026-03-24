namespace Refact.PLC.DAQ.Infrastructure.Entities;

/// <summary>
/// Maps to [dbo].[STS_MODEL_TB].
/// </summary>
public class StsModelEntity
{
    public string Model { get; set; } = string.Empty;
    public string? ModelDesc { get; set; }
    public string? ProductionQty { get; set; }
    public string? FinishedQty { get; set; }
    public string? DefectiveQty { get; set; }
    public string? Yield { get; set; }
    public string CreatedTime { get; set; } = string.Empty;
    public string? UpdatedTime { get; set; }
}
