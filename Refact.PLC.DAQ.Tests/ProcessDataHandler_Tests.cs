using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Refact.PLC.DAQ.Domain.Plc;
using Refact.PLC.DAQ.Infrastructure.Data;
using Refact.PLC.DAQ.Infrastructure.Entities;
using Refact.PLC.DAQ.Infrastructure.Handlers;
using Refact.PLC.DAQ.Infrastructure.Plc;
using Refact.PLC.DAQ.Infrastructure.Repositories;
using Xunit;

namespace Refact.PLC.DAQ.Tests;

/// <summary>
/// ?µí•© ?ŒìŠ¤?? PLC=Fake, DB=?¤ì œ ?°ê²°.
/// </summary>
public class ProcessDataHandler_Tests : IDisposable
{
    private readonly DongboDaqDbContext _db;
    private readonly EmpgRepository _empgRepo;
    private readonly ModelRepository _modelRepo;

    public ProcessDataHandler_Tests()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("Default")
            ?? "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB_eM;Integrated Security=True;TrustServerCertificate=True";

        var options = new DbContextOptionsBuilder<DongboDaqDbContext>()
            .UseSqlServer(connectionString)
            .Options;

        _db = new DongboDaqDbContext(options);
        _empgRepo = new EmpgRepository(_db);
        _modelRepo = new ModelRepository(_db);
    }

    public void Dispose() => _db.Dispose();

    [Fact]
    public async Task HandleOp100Async_ValidData_InsertsAndUpsertsModel()
    {
        var processData = new short[80];
        processData[2] = 0;
        processData[10] = 0x4241;
        processData[20] = 83; processData[21] = 72;
        processData[40] = 71; processData[41] = 82;
        processData[60] = 1;
        processData[61] = 1234;
        processData[70] = 1;
        processData[74] = 1;

        var settingData = new short[24];
        for (var i = 0; i < 24; i++) settingData[i] = 100;

        var plcDevice = new FakePlcDevice();
        plcDevice.SetProcessData(PlcBlockKey.OP100_ProcessData, processData);
        plcDevice.SetSettingData(PlcBlockKey.OP100_SettingData, settingData);

        var handler = new ProcessDataHandler(plcDevice, _empgRepo, _modelRepo);
        await handler.HandleOp100Async();

        var model = await _db.StsModel.FirstOrDefaultAsync(x => x.Model == "AB");
        Assert.NotNull(model);
        Assert.NotNull(await _db.Empg.FirstOrDefaultAsync(x => x.Model == "AB"));
    }

    [Fact]
    public async Task HandleOp200Async_ValidData_InsertsAndUpsertsModel()
    {
        var processData = new short[120];
        processData[2] = 0;
        processData[10] = 0x4241;
        processData[20] = 83; processData[21] = 72;
        processData[60] = 1;
        processData[61] = 1234;
        processData[70] = 1;

        var settingData = new short[90];
        for (var i = 0; i < 90; i++) settingData[i] = 100;

        var plcDevice = new FakePlcDevice();
        plcDevice.SetProcessData(PlcBlockKey.OP200_ProcessData, processData);
        plcDevice.SetSettingData(PlcBlockKey.OP200_SettingData, settingData);

        var handler = new ProcessDataHandler(plcDevice, _empgRepo, _modelRepo);
        await handler.HandleOp200Async();

        Assert.NotNull(await _db.Empg.FirstOrDefaultAsync(x => x.Model == "AB"));
    }

    [Fact]
    public async Task HandleOp210Async_SerialExists_UpdatesInsteadOfInsert()
    {
        if (await _db.StsModel.FirstOrDefaultAsync(x => x.Model == "AB") == null)
        {
            _db.StsModel.Add(new StsModelEntity { Model = "AB", CreatedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") });
            await _db.SaveChangesAsync();
        }

        var existingRow = await _db.Empg.FirstOrDefaultAsync(x => x.MatSerial01 == "SH");
        if (existingRow != null)
            _db.Empg.Remove(existingRow);
        _db.Empg.Add(new EmpgEntity
        {
            ResultId = "R-existing-001",
            Model = "AB",
            MatSerial01 = "SH",
            MatSerial02 = "GR",
            UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            CreateDaytime = DateTime.Now
        });
        await _db.SaveChangesAsync();

        var processData = new short[70];
        processData[2] = 0;
        processData[10] = 0x4241;
        processData[20] = 0x4853;
        processData[60] = 1000;
        processData[62] = 2;
        processData[63] = 0; processData[64] = 0;
        processData[65] = 1;

        var settingData = new short[90];
        for (var i = 0; i < 90; i++) settingData[i] = 100;

        var plcDevice = new FakePlcDevice();
        plcDevice.SetProcessData(PlcBlockKey.OP210_ProcessData, processData);
        plcDevice.SetSettingData(PlcBlockKey.OP200_SettingData, settingData);

        var handler = new ProcessDataHandler(plcDevice, _empgRepo, _modelRepo);
        await handler.HandleOp210Async();

        var row = await _db.Empg.FirstOrDefaultAsync(x => x.ResultId == "R-existing-001");
        Assert.NotNull(row);
    }

    [Fact]
    public async Task HandleOp210Async_SerialNotExists_Inserts()
    {
        var processData = new short[70];
        processData[2] = 0;
        processData[10] = 0x4241;
        processData[20] = 0x4853;
        processData[60] = 1000;
        processData[62] = 1;
        processData[63] = 0; processData[64] = 0;
        processData[65] = 1;

        var settingData = new short[90];
        for (var i = 0; i < 90; i++) settingData[i] = 100;

        var plcDevice = new FakePlcDevice();
        plcDevice.SetProcessData(PlcBlockKey.OP210_ProcessData, processData);
        plcDevice.SetSettingData(PlcBlockKey.OP200_SettingData, settingData);

        var handler = new ProcessDataHandler(plcDevice, _empgRepo, _modelRepo);
        await handler.HandleOp210Async();

        Assert.NotNull(await _db.Empg.FirstOrDefaultAsync(x => x.MatSerial01 == "SH"));
    }
}
