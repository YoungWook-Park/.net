namespace Refact.PLC.DAQ.Domain.Parsed;

/// <summary>
/// Parsed result of Parser_ProcessData_Op220.
/// </summary>
public record Op220ProcessParsed(
    string Repair,
    string Model,
    string MatSerial01,
    string TotalJudge,
    string Apd31,
    string Apd32,
    string Apd33
);
