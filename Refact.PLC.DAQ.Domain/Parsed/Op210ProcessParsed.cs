namespace Refact.PLC.DAQ.Domain.Parsed;

/// <summary>
/// Parsed result of Parser_ProcessData_Op210.
/// </summary>
public record Op210ProcessParsed(
    string Repair,
    string Model,
    string MatSerial01,
    string TotalJudge,
    string Apd27,
    string Apd28,
    string Apd29,
    string Apd30
);
