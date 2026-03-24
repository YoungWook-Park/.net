using Refact.PLC.DAQ.Domain.Dtos;
using Refact.PLC.DAQ.Domain.Parsed;

namespace Refact.PLC.DAQ.Domain.Mapping;

/// <summary>
/// Maps Op210ProcessParsed and Op200SettingParsed to Op210 DTOs.
/// Op210 (RunOut Check) uses Op200 Setting for Sp31-Sp36.
/// Object is created first, then returned for easier debugging.
/// </summary>
public static class Op210ToDtoMapper
{
    public static Op210EmpgInsertDto ToInsertDto(
        Op210ProcessParsed process,
        Op200SettingParsed setting,
        string resultId,
        string updateTime,
        string createDayTime)
    {
        var dto = new Op210EmpgInsertDto(
            ResultId: resultId,
            UpdateTime: updateTime,
            Repair: process.Repair,
            Model: process.Model,
            MatSerial01: process.MatSerial01,
            MatSerial02: "",
            TotalJudge: process.TotalJudge,
            CreateDayTime: createDayTime,
            Apd27: process.Apd27,
            Apd28: process.Apd28,
            Apd29: process.Apd29,
            Apd30: process.Apd30,
            Sp31: setting.Sp31,
            Sp32: setting.Sp32,
            Sp33: setting.Sp33,
            Sp34: setting.Sp34,
            Sp35: setting.Sp35,
            Sp36: setting.Sp36
        );

        return dto;
    }

    public static Op210EmpgUpdateDto ToUpdateDto(Op210ProcessParsed process, Op200SettingParsed setting, string updateTime)
    {
        var dto = new Op210EmpgUpdateDto(
            UpdateTime: updateTime,
            TotalJudge: process.TotalJudge,
            Apd27: process.Apd27,
            Apd28: process.Apd28,
            Apd29: process.Apd29,
            Apd30: process.Apd30,
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
