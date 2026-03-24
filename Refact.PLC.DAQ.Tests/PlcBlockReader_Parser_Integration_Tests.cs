using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Infrastructure.Plc;
using Refact.PLC.DAQ.Domain.Parsers;
using Refact.PLC.DAQ.Domain.Plc;
using Xunit;

namespace Refact.PLC.DAQ.Tests;

/// <summary>
/// Verifies the pipeline: FakePlcDevice -> Parser produces expected results.
/// </summary>
public class PlcBlockReader_Parser_Integration_Tests
{
    [Fact]
    public async Task FakePlcDevice_Op200ProcessData_Parser_ReturnsExpectedValues()
    {
        var data = new short[120];
        data[0] = 1;
        data[2] = 0;   // Repair = AUTO
        data[10] = 65; data[11] = 66;  // "AB" model
        data[20] = 83; data[21] = 72;  // "SH" shaft serial
        data[60] = 1;  // TotalJudge = OK
        data[61] = 1234;  // /100 -> 12.34
        data[70] = 1;  // Guide_Ring_Judge = OK

        var plcDevice = new FakePlcDevice();
        plcDevice.SetProcessData(PlcBlockKey.OP200_ProcessData, data);

        var block = await plcDevice.ReadProcessBlockAsync(PlcBlockKey.OP200_ProcessData);
        var parsed = Parser_ProcessData_Op200.Parse(block);

        Assert.NotNull(parsed);
        Assert.Equal(DbRepairCode.AUTO, parsed.Repair);
        Assert.Equal(DbJudgeCode.OK, parsed.TotalJudge);
        Assert.Equal("12.34", parsed.Apd01);
        Assert.Equal(DbJudgeCode.OK, parsed.Apd07);
    }

    [Fact]
    public async Task FakePlcDevice_UnknownKey_ThrowsKeyNotFoundException()
    {
        var plcDevice = new FakePlcDevice();
        plcDevice.SetProcessData(PlcBlockKey.OP200_ProcessData, new short[10]);

        await Assert.ThrowsAsync<KeyNotFoundException>(
            () => plcDevice.ReadProcessBlockAsync("Unknown_Device_Key"));
    }
}
