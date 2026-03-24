using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Domain.Mapping;
using Refact.PLC.DAQ.Domain.Parsers;
using Xunit;

namespace Refact.PLC.DAQ.Tests;

public class Op100ToDtoMapper_Tests
{
    [Fact]
    public void ToInsertDto_AfterParse_MapsAllFields()
    {
        var processData = new short[100];
        processData[2] = 0;   // Repair = AUTO
        processData[60] = 1;  // TotalJudge = OK
        processData[61] = 1234;  // Apd01 = 12.34
        processData[70] = 1;  // Apd07 = OK
        processData[74] = 2;  // Apd10 = NG

        var settingData = new short[30];
        settingData[0] = 100;   // Sp01 = 1.00
        settingData[1] = 200;   // Sp02 = 2.00
        settingData[20] = 1000; settingData[21] = 0;  // Sp13 ShortToInt/10000

        var process = Parser_ProcessData_Op100.Parse(processData);
        var setting = Parser_SettingData_Op100.Parse(settingData);

        Assert.NotNull(process);
        Assert.NotNull(setting);

        var dto = Op100ToDtoMapper.ToInsertDto(process!, setting!, "R001", "20250313120000", "20250313");

        Assert.Equal("R001", dto.ResultId);
        Assert.Equal("20250313120000", dto.UpdateTime);
        Assert.Equal("20250313", dto.CreateDayTime);
        Assert.Equal(DbRepairCode.AUTO, dto.Repair);
        Assert.Equal(DbJudgeCode.OK, dto.TotalJudge);
        Assert.Equal("12.34", dto.Apd01);
        Assert.Equal(DbJudgeCode.OK, dto.Apd07);
        Assert.Equal(DbJudgeCode.NG, dto.Apd10);
        Assert.Equal("1.00", dto.Sp01);
        Assert.Equal("2.00", dto.Sp02);
        Assert.Equal("0.1000", dto.Sp13);
    }
}
