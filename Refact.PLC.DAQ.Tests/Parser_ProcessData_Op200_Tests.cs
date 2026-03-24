using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Domain.Parsers;
using Refact.PLC.DAQ.Domain.Plc;
using Xunit;

namespace Refact.PLC.DAQ.Tests;

public class Parser_ProcessData_Op200_Tests
{
    [Fact]
    public void Parse_NullData_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => Parser_ProcessData_Op200.Parse(null!));
    }

    [Fact]
    public void Parse_ValidData_ReturnsParsedWithExpectedValues()
    {
        var data = new short[120];
        data[0] = 1;   // BackUp_Start (not in Parsed)
        data[2] = 0;   // Repair = AUTO
        data[10] = 65; data[11] = 66;  // "AB" model name (simplified)
        data[20] = 83; data[21] = 72;  // "SH" shaft serial
        data[60] = 1;  // TotalJudgment = OK
        data[61] = 1234;  // /100 -> 12.34
        data[70] = 1;  // Guide_Ring_Judge = OK

        var result = Parser_ProcessData_Op200.Parse(data);

        Assert.NotNull(result);
        Assert.Equal(DbRepairCode.AUTO, result.Repair);
        Assert.Equal(DbJudgeCode.OK, result.TotalJudge);
        Assert.Equal("12.34", result.Apd01);
        Assert.Equal(DbJudgeCode.OK, result.Apd07);
    }

    [Fact]
    public void PlcDataConverter_ShortToString_ConvertsCorrectly()
    {
        // Each short is 2 bytes (little-endian). Value 65 = 0x41,0x00 -> stops at 0, returns "A"
        var data = new short[] { 0, 0, 65, 0 };
        var result = PlcDataConverter.ShortToString(data, 2, 2);
        Assert.Equal("A", result);
    }
}
