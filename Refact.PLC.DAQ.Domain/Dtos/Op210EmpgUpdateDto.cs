namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// OP210 EMPG UPDATE DTO.
/// Updates only OP210-specific columns when serial exists in DB.
/// </summary>
public record Op210EmpgUpdateDto(
    string UpdateTime,
    string TotalJudge,
    string Apd27,  // RunOutCheck_Input
    string Apd28,  // RunOutCheck_Input_Judgment
    string Apd29,  // RunOutCheck_Space
    string Apd30,  // RunOutCheck_Space_Judgment
    string Sp31, string Sp32, string Sp33, string Sp34, string Sp35, string Sp36
);
