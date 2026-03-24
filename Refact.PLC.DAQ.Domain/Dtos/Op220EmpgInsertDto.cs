namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// OP220 (Guiding Press Fitting, ShortDistance) EMPG INSERT DTO.
/// Used when serial not found in DB (fallback insert).
/// </summary>
public record Op220EmpgInsertDto(
    string ResultId,
    string UpdateTime,
    string Repair,
    string Model,
    string MatSerial01,
    string MatSerial02,
    string TotalJudge,
    string CreateDayTime,
    string Apd31,  // GuidingPressFitting_Judgment
    string Apd32,  // Guiding_ShortDistance_Check
    string Apd33,  // Guiding_ShortDistance_Judgment
    string Sp37, string Sp38  // Guiding_ShortDistance SP columns if any
);
