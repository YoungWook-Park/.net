using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Domain.Mapping;
using Refact.PLC.DAQ.Domain.Parsers;
using Xunit;

namespace Refact.PLC.DAQ.Tests;

public class Op200ToDtoMapper_Tests
{
    [Fact]
    public void ToInsertDto_AfterParse_MapsAllFields()
    {
        var processData = new short[120];
        processData[2] = 1;   // Repair = REPAIR
        processData[60] = 2;  // TotalJudge = NG
        processData[61] = 567;   // Apd01 Guide_Ring_R1_Load = 5.67
        processData[70] = 1;     // Apd07 Judge = OK
        processData[72] = 1000;  // Apd09 Bearing_R1_Load = 10.00
        processData[97] = 4;     // Apd26 End_Plate_Judge = PASS

        var settingData = new short[90];
        settingData[0] = 50;   // Sp01 = 0.50
        settingData[48] = 1000; settingData[49] = 0;  // Sp25 ShortToInt/10000

        var process = Parser_ProcessData_Op200.Parse(processData);
        var setting = Parser_SettingData_Op200.Parse(settingData);

        Assert.NotNull(process);
        Assert.NotNull(setting);

        var dto = Op200ToDtoMapper.ToInsertDto(process!, setting!, "R002", "20250313120100", "20250313");

        Assert.Equal("R002", dto.ResultId);
        Assert.Equal("20250313120100", dto.UpdateTime);
        Assert.Equal("20250313", dto.CreateDayTime);
        Assert.Equal(DbRepairCode.REPAIR, dto.Repair);
        Assert.Equal(DbJudgeCode.NG, dto.TotalJudge);
        Assert.Equal("5.67", dto.Apd01);
        Assert.Equal(DbJudgeCode.OK, dto.Apd07);
        Assert.Equal("10.00", dto.Apd09);
        Assert.Equal(DbJudgeCode.PASS, dto.Apd26);
        Assert.Equal("", dto.Apd27);
        Assert.Equal("0.50", dto.Sp01);
        Assert.Equal("0.1000", dto.Sp25);
    }
}
