using Refact.PLC.DAQ.Domain.Dtos;
using Refact.PLC.DAQ.Domain.Parsed;

namespace Refact.PLC.DAQ.Domain.Mapping;

/// <summary>
/// Maps Op230ProcessParsed and Op230SettingParsed to Op230 DTOs.
/// Object is created first, then returned for easier debugging.
/// </summary>
public static class Op230ToDtoMapper
{
    public static Op230EmpgInsertDto ToInsertDto(
        Op230ProcessParsed process,
        Op230SettingParsed setting,
        string resultId,
        string updateTime,
        string createDayTime)
    {
        var dto = new Op230EmpgInsertDto(
            ResultId: resultId,
            UpdateTime: updateTime,
            Repair: process.Repair,
            Model: process.Model,
            MatSerial01: process.MatSerial01,
            MatSerial02: process.MatSerial02,
            TotalJudge: process.TotalJudge,
            CreateDayTime: createDayTime,
            Apd35: process.Apd35,
            Apd36: process.Apd36,
            Apd37: process.Apd37,
            Apd38: process.Apd38,
            Apd39: process.Apd39,
            Apd40: process.Apd40,
            Apd41: process.Apd41,
            Apd42: process.Apd42,
            Apd43: process.Apd43,
            Apd44: process.Apd44,
            Sp39: setting.Sp39,
            Sp40: setting.Sp40,
            Sp41: setting.Sp41,
            Sp42: setting.Sp42,
            Sp43: setting.Sp43,
            Sp44: setting.Sp44
        );

        return dto;
    }

    public static Op230EmpgUpdateDto ToUpdateDto(Op230ProcessParsed process, string updateTime)
    {
        var dto = new Op230EmpgUpdateDto(
            UpdateTime: updateTime,
            TotalJudge: process.TotalJudge,
            Apd35: process.Apd35,
            Apd36: process.Apd36,
            Apd37: process.Apd37,
            Apd38: process.Apd38,
            Apd39: process.Apd39,
            Apd40: process.Apd40,
            Apd41: process.Apd41,
            Apd42: process.Apd42,
            Apd43: process.Apd43,
            Apd44: process.Apd44
        );

        return dto;
    }
}
