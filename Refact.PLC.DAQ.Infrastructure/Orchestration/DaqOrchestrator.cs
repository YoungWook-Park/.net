using Refact.PLC.DAQ.Domain.Handlers;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Infrastructure.Orchestration;

/// <summary>
/// PLC r12000 ?îÏ≤≠ ÎπÑÌä∏ ?¥ÎßÅ ???∞Ïù¥??Ï≤òÎ¶¨ ??r12001 ?ëÎãµ(OK/NG).
/// </summary>
public class DaqOrchestrator
{
    private readonly IPlcDevice _plcDevice;
    private readonly IProcessDataHandler _handler;
    private readonly int _pollIntervalMs;

    public DaqOrchestrator(IPlcDevice plcDevice, IProcessDataHandler handler, int pollIntervalMs = 50)
    {
        _plcDevice = plcDevice;
        _handler = handler;
        _pollIntervalMs = pollIntervalMs;
    }

    /// <summary>
    /// r12000 Bit0=1 ?ÄÍ∏???HandleOp100Async ?§Ìñâ ???±Í≥µ ??OK(1Ï¥????¥Ï†ú), ?§Ìå® ??NG.
    /// </summary>
    public async Task RunAsync(CancellationToken ct = default)
    {
        while (!ct.IsCancellationRequested)
        {
            try
            {
                var requestWord = await _plcDevice.ReadRequestWordAsync(ct);
                var requestBit0 = PlcReadDef.IsBitSet(requestWord, PlcReadDef.R12000.Bit0_Request);

                if (requestBit0)
                {
                    _plcDevice.WriteBuffer.R12001.ClearNg();
                    try
                    {
                        await _handler.HandleOp200Async(ct);
                        _plcDevice.WriteBuffer.R12001.SetOk();
                        await _plcDevice.FlushWriteAsync(ct);
                        await Task.Delay(1000, ct);
                        _plcDevice.WriteBuffer.R12001.ClearOk();
                        await _plcDevice.FlushWriteAsync(ct);
                    }
                    catch (Exception)
                    {
                        _plcDevice.WriteBuffer.R12001.SetNg();
                        await _plcDevice.FlushWriteAsync(ct);
                        throw;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }

            await Task.Delay(_pollIntervalMs, ct);
        }
    }
}
