namespace Refact.PLC.DAQ.Domain.Plc;

/// <summary>
/// PLC Read/Write ?µÌï© ?îÎ∞î?¥Ïä§.
/// Read(Process, Setting, Request) + WriteBuffer(r12001~12005).
/// </summary>
public interface IPlcDevice
{
    /// <summary>
    /// Write Î≤ÑÌçº. r12001~12005. SetOk/ClearOk ?±ÏúºÎ°?ÎπÑÌä∏ ?§Ï†ï ??FlushWriteAsync ?∏Ï∂ú.
    /// </summary>
    PlcWriteBuffer WriteBuffer { get; }

    /// <summary>
    /// r12000 ?îÏ≤≠ ?åÎìú ?ΩÍ∏∞. Bit0=1?¥Î©¥ Ï≤òÎ¶¨ ?îÏ≤≠.
    /// </summary>
    Task<ushort> ReadRequestWordAsync(CancellationToken ct = default);

    Task<short[]> ReadProcessBlockAsync(string deviceKey, CancellationToken ct = default);
    Task<short[]> ReadSettingBlockAsync(string deviceKey, CancellationToken ct = default);

    /// <summary>
    /// WriteBuffer??ushort[5]Î•?PLCÎ°??ÑÏÜ°.
    /// </summary>
    Task FlushWriteAsync(CancellationToken ct = default);
}
