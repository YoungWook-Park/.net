using Refact.PLC.DAQ.Domain.Dtos;
using Refact.PLC.DAQ.Domain.Handlers;
using Refact.PLC.DAQ.Domain.Mapping;
using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Parsers;
using Refact.PLC.DAQ.Domain.Plc;
using Refact.PLC.DAQ.Infrastructure.Repositories;

namespace Refact.PLC.DAQ.Infrastructure.Handlers;

public class ProcessDataHandler : IProcessDataHandler
{
    private readonly IPlcDevice _plcDevice;
    private readonly EmpgRepository _empgRepo;
    private readonly ModelRepository _modelRepo;

    public ProcessDataHandler(IPlcDevice plcDevice, EmpgRepository empgRepo, ModelRepository modelRepo)
    {
        _plcDevice = plcDevice;
        _empgRepo = empgRepo;
        _modelRepo = modelRepo;
    }

    public async Task HandleOp100Async(CancellationToken ct = default)
    {
        var processData = await _plcDevice.ReadProcessBlockAsync(PlcBlockKey.OP100_ProcessData, ct);
        var settingData = await _plcDevice.ReadSettingBlockAsync(PlcBlockKey.OP100_SettingData, ct);

        var process = Parser_ProcessData_Op100.Parse(processData);
        var setting = Parser_SettingData_Op100.Parse(settingData);
        if (process == null || setting == null) return;

        var tranTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var resultId = $"R-{tranTime}";
        var createDayTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        await _modelRepo.UpsertAndUpdateCountsAsync(process.Model, process.TotalJudge, ct);
        var dto = Op100ToDtoMapper.ToInsertDto(process, setting, resultId, tranTime, createDayTime);
        await _empgRepo.InsertAsync(dto, ct);
    }

    public async Task HandleOp200Async(CancellationToken ct = default)
    {
        var processData = await _plcDevice.ReadProcessBlockAsync(PlcBlockKey.OP200_ProcessData, ct);
        var settingData = await _plcDevice.ReadSettingBlockAsync(PlcBlockKey.OP200_SettingData, ct);

        var process = Parser_ProcessData_Op200.Parse(processData);
        var setting = Parser_SettingData_Op200.Parse(settingData);
        if (process == null || setting == null) return;

        var tranTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var resultId = $"R-{tranTime}";
        var createDayTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        await _modelRepo.UpsertAndUpdateCountsAsync(process.Model, process.TotalJudge, ct);
        var dto = Op200ToDtoMapper.ToInsertDto(process, setting, resultId, tranTime, createDayTime);
        await _empgRepo.InsertAsync(dto, ct);
    }

    public async Task HandleOp210Async(CancellationToken ct = default)
    {
        var processData = await _plcDevice.ReadProcessBlockAsync(PlcBlockKey.OP210_ProcessData, ct);
        var settingData = await _plcDevice.ReadSettingBlockAsync(PlcBlockKey.OP200_SettingData, ct);

        var process = Parser_ProcessData_Op210.Parse(processData);
        var setting = Parser_SettingData_Op200.Parse(settingData);
        if (process == null || setting == null) return;

        var tranTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var createDayTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        var existing = await _empgRepo.FindByMatSerial01Async(process.MatSerial01, ct);
        if (existing != null)
        {
            await _modelRepo.UpsertAndUpdateCountsAsync(process.Model, process.TotalJudge, ct);
            var updateDto = Op210ToDtoMapper.ToUpdateDto(process, setting, tranTime);
            await _empgRepo.UpdateAsync(existing.ResultId, updateDto, ct);
        }
        else
        {
            await _modelRepo.UpsertAndUpdateCountsAsync(process.Model, process.TotalJudge, ct);
            var resultId = $"R-{tranTime}";
            var insertDto = Op210ToDtoMapper.ToInsertDto(process, setting, resultId, tranTime, createDayTime);
            await _empgRepo.InsertAsync(insertDto, ct);
        }
    }

    public async Task HandleOp220Async(CancellationToken ct = default)
    {
        var processData = await _plcDevice.ReadProcessBlockAsync(PlcBlockKey.OP220_ProcessData, ct);
        var settingData = await _plcDevice.ReadSettingBlockAsync(PlcBlockKey.OP200_SettingData, ct);

        var process = Parser_ProcessData_Op220.Parse(processData);
        var setting = Parser_SettingData_Op200.Parse(settingData);
        if (process == null || setting == null) return;

        var tranTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var createDayTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        var existing = await _empgRepo.FindByMatSerial01Async(process.MatSerial01, ct);
        if (existing != null)
        {
            await _modelRepo.UpsertAndUpdateCountsAsync(process.Model, process.TotalJudge, ct);
            var updateDto = Op220ToDtoMapper.ToUpdateDto(process, tranTime);
            await _empgRepo.UpdateAsync(existing.ResultId, updateDto, ct);
        }
        else
        {
            await _modelRepo.UpsertAndUpdateCountsAsync(process.Model, process.TotalJudge, ct);
            var resultId = $"R-{tranTime}";
            var insertDto = Op220ToDtoMapper.ToInsertDto(process, setting, resultId, tranTime, createDayTime);
            await _empgRepo.InsertAsync(insertDto, ct);
        }
    }

    public async Task HandleOp230Async(CancellationToken ct = default)
    {
        var processData = await _plcDevice.ReadProcessBlockAsync(PlcBlockKey.OP230_ProcessData, ct);
        var settingData = await _plcDevice.ReadSettingBlockAsync(PlcBlockKey.OP230_SettingData, ct);

        var process = Parser_ProcessData_Op230.Parse(processData);
        var setting = Parser_SettingData_Op230.Parse(settingData);
        if (process == null || setting == null) return;

        var tranTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        var createDayTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        var existing = await _empgRepo.FindByMatSerial01Async(process.MatSerial01, ct);
        if (existing != null)
        {
            await _modelRepo.UpsertAndUpdateCountsAsync(process.Model, process.TotalJudge, ct);
            var updateDto = Op230ToDtoMapper.ToUpdateDto(process, tranTime);
            await _empgRepo.UpdateAsync(existing.ResultId, updateDto, ct);
        }
        else
        {
            await _modelRepo.UpsertAndUpdateCountsAsync(process.Model, process.TotalJudge, ct);
            var resultId = $"R-{tranTime}";
            var insertDto = Op230ToDtoMapper.ToInsertDto(process, setting, resultId, tranTime, createDayTime);
            await _empgRepo.InsertAsync(insertDto, ct);
        }
    }
}
