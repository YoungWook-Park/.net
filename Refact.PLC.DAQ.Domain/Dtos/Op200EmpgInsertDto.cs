namespace Refact.PLC.DAQ.Domain.Dtos;

/// <summary>
/// OP200 (Guide Ring Spacer, Bearing, Snap Ring, End Plate) EMPG INSERT DTO.
/// Maps to EMPG table columns used by ProcessData_Op200.
/// </summary>
public record Op200EmpgInsertDto(
    string ResultId,
    string UpdateTime,
    string Repair,
    string Model,
    string MatSerial01,
    string MatSerial02,
    string TotalJudge,
    string CreateDayTime,
    string Apd01, string Apd02, string Apd03, string Apd04, string Apd05, string Apd06,
    string Apd07, string Apd08,  // Guide_Ring_Spacer
    string Apd09, string Apd10, string Apd11, string Apd12, string Apd13, string Apd14,
    string Apd15, string Apd16,  // Bearing
    string Apd17, string Apd18, string Apd19, string Apd20, string Apd21, string Apd22,
    string Apd23, string Apd24, string Apd25, string Apd26,  // Snap_Ring_Groove, Heigh, End_Plate
    string Apd27, string Apd28, string Apd29, string Apd30, string Apd31, string Apd32,  // reserved
    string Sp01, string Sp02, string Sp03, string Sp04, string Sp05, string Sp06,
    string Sp07, string Sp08, string Sp09, string Sp10, string Sp11, string Sp12,
    string Sp13, string Sp14, string Sp15, string Sp16, string Sp17, string Sp18,
    string Sp19, string Sp20, string Sp21, string Sp22, string Sp23, string Sp24,
    string Sp25, string Sp26, string Sp27, string Sp28, string Sp29, string Sp30,
    string Sp31, string Sp32, string Sp33, string Sp34, string Sp35, string Sp36
);
