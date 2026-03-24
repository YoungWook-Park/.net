namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// OP220 EMPG UPDATE DTO.
/// Updates only OP220-specific columns when serial exists in DB.
/// </summary>
public record Op220EmpgUpdateDto(
    string UpdateTime,
    string TotalJudge,
    string Apd31,  // GuidingPressFitting_Judgment
    string Apd32,  // Guiding_ShortDistance_Check
    string Apd33   // Guiding_ShortDistance_Judgment
);
