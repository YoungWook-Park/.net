namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// OP100 (Parking Gear) EMPG INSERT DTO.
/// Maps to EMPG table columns used by ProcessData_Op100.
/// </summary>
public record Op100EmpgInsertDto(
    string ResultId,
    string UpdateTime,
    string Repair,
    string Model,
    string MatSerial01,
    string MatSerial02,
    string TotalJudge,
    string CreateDayTime,
    string Apd01,  // Parking_Gear_R1_Load
    string Apd02, string Apd03, string Apd04, string Apd05, string Apd06,
    string Apd07,  // Parking_Gear_Judge
    string Apd08,  // Parking_Gear_Index_No
    string Apd09,  // Run_Out_Data
    string Apd10,  // Run_Out_Judge
    string Sp01, string Sp02, string Sp03, string Sp04, string Sp05, string Sp06,
    string Sp07, string Sp08, string Sp09, string Sp10, string Sp11, string Sp12,
    string Sp13, string Sp14  // Run_Out_Data_Lower, Upper
);
