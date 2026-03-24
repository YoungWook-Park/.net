using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Infrastructure.Plc;

/// <summary>
/// ?åÏä§?∏Ïö© PLC ?îÎ∞î?¥Ïä§. Read??ÎØ∏Î¶¨ ?§Ï†ï???∞Ïù¥??Î∞òÌôò, Write???¥Î†•Îß??Ä??
/// </summary>
public class FakePlcDevice : IPlcDevice
{
    private readonly Dictionary<string, short[]> _processData = new();
    private readonly Dictionary<string, short[]> _settingData = new();
    private ushort _requestWord;

    public PlcWriteBuffer WriteBuffer { get; } = new();

    /// <summary>
    /// r12000 ?îÏ≤≠ ?åÎìú ?§Ï†ï. Bit0=1?¥Î©¥ Ï≤òÎ¶¨ ?îÏ≤≠.
    /// </summary>
    public void SetRequestWord(ushort value)
    {
        _requestWord = value;
    }

    /// <summary>
    /// Bit0Î•?Set?òÏó¨ ?îÏ≤≠ ?úÎ??àÏù¥??
    /// </summary>
    public void SetRequestBit0()
    {
        _requestWord |= 1;
    }

    public void SetProcessData(string deviceKey, short[] data)
    {
        _processData[deviceKey] = data;
    }

    public void SetSettingData(string deviceKey, short[] data)
    {
        _settingData[deviceKey] = data;
    }

    public Task<ushort> ReadRequestWordAsync(CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();
        return Task.FromResult(_requestWord);
    }

    public Task<short[]> ReadProcessBlockAsync(string deviceKey, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();
        if (_processData.TryGetValue(deviceKey, out var data))
            return Task.FromResult(data);
        throw new KeyNotFoundException($"No process data for: {deviceKey}");
    }

    public Task<short[]> ReadSettingBlockAsync(string deviceKey, CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();
        if (_settingData.TryGetValue(deviceKey, out var data))
            return Task.FromResult(data);
        throw new KeyNotFoundException($"No setting data for: {deviceKey}");
    }

    /// <summary>
    /// Fake: ?ÑÏÜ° ?¥Î†•Îß??Ä?? ?§Ï†ú ?ÑÏÜ° ?ÜÏùå.
    /// </summary>
    public List<ushort[]> WriteHistory { get; } = new();

    public Task FlushWriteAsync(CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();
        WriteHistory.Add(WriteBuffer.Snapshot());
        return Task.CompletedTask;
    }
}
