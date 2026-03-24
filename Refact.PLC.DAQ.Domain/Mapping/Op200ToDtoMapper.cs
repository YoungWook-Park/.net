using Refact.PLC.DAQ.Domain.Dtos;
using Refact.PLC.DAQ.Domain.Parsed;

namespace Refact.PLC.DAQ.Domain.Mapping;

/// <summary>
/// Maps Op200ProcessParsed and Op200SettingParsed to Op200EmpgInsertDto.
/// Object is created first, then returned for easier debugging.
/// </summary>
public static class Op200ToDtoMapper
{
    public static Op200EmpgInsertDto ToInsertDto(
        Op200ProcessParsed process,
        Op200SettingParsed setting,
        string resultId,
        string updateTime,
        string createDayTime)
    {
        var dto = new Op200EmpgInsertDto(
            ResultId: resultId,
            UpdateTime: updateTime,
            Repair: process.Repair,
            Model: process.Model,
            MatSerial01: process.MatSerial01,
            MatSerial02: process.MatSerial02,
            TotalJudge: process.TotalJudge,
            CreateDayTime: createDayTime,
            Apd01: process.Apd01,
            Apd02: process.Apd02,
            Apd03: process.Apd03,
            Apd04: process.Apd04,
            Apd05: process.Apd05,
            Apd06: process.Apd06,
            Apd07: process.Apd07,
            Apd08: process.Apd08,
            Apd09: process.Apd09,
            Apd10: process.Apd10,
            Apd11: process.Apd11,
            Apd12: process.Apd12,
            Apd13: process.Apd13,
            Apd14: process.Apd14,
            Apd15: process.Apd15,
            Apd16: process.Apd16,
            Apd17: process.Apd17,
            Apd18: process.Apd18,
            Apd19: process.Apd19,
            Apd20: process.Apd20,
            Apd21: process.Apd21,
            Apd22: process.Apd22,
            Apd23: process.Apd23,
            Apd24: process.Apd24,
            Apd25: process.Apd25,
            Apd26: process.Apd26,
            Apd27: "",
            Apd28: "",
            Apd29: "",
            Apd30: "",
            Apd31: "",
            Apd32: "",
            Sp01: setting.Sp01,
            Sp02: setting.Sp02,
            Sp03: setting.Sp03,
            Sp04: setting.Sp04,
            Sp05: setting.Sp05,
            Sp06: setting.Sp06,
            Sp07: setting.Sp07,
            Sp08: setting.Sp08,
            Sp09: setting.Sp09,
            Sp10: setting.Sp10,
            Sp11: setting.Sp11,
            Sp12: setting.Sp12,
            Sp13: setting.Sp13,
            Sp14: setting.Sp14,
            Sp15: setting.Sp15,
            Sp16: setting.Sp16,
            Sp17: setting.Sp17,
            Sp18: setting.Sp18,
            Sp19: setting.Sp19,
            Sp20: setting.Sp20,
            Sp21: setting.Sp21,
            Sp22: setting.Sp22,
            Sp23: setting.Sp23,
            Sp24: setting.Sp24,
            Sp25: setting.Sp25,
            Sp26: setting.Sp26,
            Sp27: setting.Sp27,
            Sp28: setting.Sp28,
            Sp29: setting.Sp29,
            Sp30: setting.Sp30,
            Sp31: setting.Sp31,
            Sp32: setting.Sp32,
            Sp33: setting.Sp33,
            Sp34: setting.Sp34,
            Sp35: setting.Sp35,
            Sp36: setting.Sp36
        );

        return dto;
    }
}
