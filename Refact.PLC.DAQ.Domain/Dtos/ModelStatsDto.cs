namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// STS_MODEL_TB row representation.
/// </summary>
public record ModelStatsDto(
    string Model,
    double ProductionQty,
    double FinishedQty,
    double DefectiveQty,
    double Yield
);
