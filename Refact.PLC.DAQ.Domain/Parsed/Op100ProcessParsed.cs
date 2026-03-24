namespace Refact.PLC.DAQ.Domain.Parsed;

/// <summary>
/// Parsed result of Parser_ProcessData_Op100. No static state; use for mapping and testing.
/// </summary>
public record Op100ProcessParsed(
    string Repair,
    string Model,
    string MatSerial01,
    string MatSerial02,
    string TotalJudge,
    string Apd01,
    string Apd02,
    string Apd03,
    string Apd04,
    string Apd05,
    string Apd06,
    string Apd07,
    string Apd08,
    string Apd09,
    string Apd10
);
