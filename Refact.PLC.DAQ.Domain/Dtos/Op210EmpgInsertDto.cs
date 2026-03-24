namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// OP210 (RunOut Check) EMPG INSERT DTO.
/// Used when serial not found in DB (fallback insert).
/// </summary>
public record Op210EmpgInsertDto(
    string ResultId,
    string UpdateTime,
    string Repair,
    string Model,
    string MatSerial01,
    string MatSerial02,
    string TotalJudge,
    string CreateDayTime,
    string Apd27,  // RunOutCheck_Input
    string Apd28,  // RunOutCheck_Input_Judgment
    string Apd29,  // RunOutCheck_Space
    string Apd30,  // RunOutCheck_Space_Judgment
    string Sp31, string Sp32, string Sp33, string Sp34, string Sp35, string Sp36
);
