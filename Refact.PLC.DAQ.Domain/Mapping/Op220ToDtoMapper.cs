using Refact.PLC.DAQ.Domain.Dtos;
using Refact.PLC.DAQ.Domain.Parsed;

namespace Refact.PLC.DAQ.Domain.Mapping;

/// <summary>
/// Maps Op220ProcessParsed and Op200SettingParsed to Op220 DTOs.
/// Op220 uses Op200 Setting Sp35-Sp36 (Guiding_ShortDistance) as Sp37-Sp38.
/// Object is created first, then returned for easier debugging.
/// </summary>
public static class Op220ToDtoMapper
{
    public static Op220EmpgInsertDto ToInsertDto(
        Op220ProcessParsed process,
        Op200SettingParsed setting,
        string resultId,
        string updateTime,
        string createDayTime)
    {
        var dto = new Op220EmpgInsertDto(
            ResultId: resultId,
            UpdateTime: updateTime,
            Repair: process.Repair,
            Model: process.Model,
            MatSerial01: process.MatSerial01,
            MatSerial02: "",
            TotalJudge: process.TotalJudge,
            CreateDayTime: createDayTime,
            Apd31: process.Apd31,
            Apd32: process.Apd32,
            Apd33: process.Apd33,
            Sp37: setting.Sp35,
            Sp38: setting.Sp36
        );

        return dto;
    }

    public static Op220EmpgUpdateDto ToUpdateDto(Op220ProcessParsed process, string updateTime)
    {
        var dto = new Op220EmpgUpdateDto(
            UpdateTime: updateTime,
            TotalJudge: process.TotalJudge,
            Apd31: process.Apd31,
            Apd32: process.Apd32,
            Apd33: process.Apd33
        );

        return dto;
    }
}
