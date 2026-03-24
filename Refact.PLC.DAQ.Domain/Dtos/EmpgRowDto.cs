namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// EMPG row for read operations (serial validation, inquiry).
/// </summary>
public record EmpgRowDto(
    string ResultId,
    string Model,
    string MatSerial01,
    string MatSerial02,
    string TotalJudge,
    string UpdateTime,
    string? Apd01 = null,
    string? Apd02 = null,
    string? Apd27 = null,
    string? Apd28 = null,
    string? Apd29 = null,
    string? Apd30 = null
);
