namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// OP230 EMPG UPDATE DTO.
/// Updates only OP230-specific columns when serial exists in DB.
/// </summary>
public record Op230EmpgUpdateDto(
    string UpdateTime,
    string TotalJudge,
    string Apd35,  // Lotite_Dispensing_Judge
    string Apd36,  // Lotite_Vision_Judge
    string Apd37, string Apd38, string Apd39, string Apd40, string Apd41,
    string Apd42,  // Shaft_Oil_Cap_Press_Judge
    string Apd43,  // Shaft_Oil_Cap_Check
    string Apd44   // Shaft_Oil_Cap_Check_Judge
);
