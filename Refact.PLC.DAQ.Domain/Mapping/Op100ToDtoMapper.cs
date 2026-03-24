using Refact.PLC.DAQ.Domain.Dtos;
using Refact.PLC.DAQ.Domain.Parsed;

namespace Refact.PLC.DAQ.Domain.Mapping;

/// <summary>
/// Maps Op100ProcessParsed and Op100SettingParsed to Op100EmpgInsertDto.
/// Object is created first, then returned for easier debugging.
/// </summary>
public static class Op100ToDtoMapper
{
    public static Op100EmpgInsertDto ToInsertDto(
        Op100ProcessParsed process,
        Op100SettingParsed setting,
        string resultId,
        string updateTime,
        string createDayTime)
    {
        var dto = new Op100EmpgInsertDto(
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
            Sp14: setting.Sp14
        );

        return dto;
    }
}
