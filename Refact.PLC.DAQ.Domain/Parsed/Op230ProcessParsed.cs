namespace Refact.PLC.DAQ.Domain.Parsed;

/// <summary>
/// Parsed result of Parser_ProcessData_Op230.
/// </summary>
public record Op230ProcessParsed(
    string Repair,
    string Model,
    string MatSerial01,
    string MatSerial02,
    string TotalJudge,
    string Apd35,
    string Apd36,
    string Apd37,
    string Apd38,
    string Apd39,
    string Apd40,
    string Apd41,
    string Apd42,
    string Apd43,
    string Apd44
);
