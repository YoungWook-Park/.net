namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// OP230 (Lotite, Shaft Oil Cap) EMPG INSERT DTO.
/// </summary>
public record Op230EmpgInsertDto(
    string ResultId,
    string UpdateTime,
    string Repair,
    string Model,
    string MatSerial01,
    string MatSerial02,
    string TotalJudge,
    string CreateDayTime,
    string Apd35,  // Lotite_Dispensing_Judge
    string Apd36,  // Lotite_Vision_Judge
    string Apd37, string Apd38, string Apd39, string Apd40, string Apd41,  // Shaft_Oil_Cap_Press
    string Apd42,  // Shaft_Oil_Cap_Press_Judge
    string Apd43,  // Shaft_Oil_Cap_Check
    string Apd44,  // Shaft_Oil_Cap_Check_Judge
    string Sp39, string Sp40, string Sp41, string Sp42, string Sp43, string Sp44  // OP230 SP columns
);
