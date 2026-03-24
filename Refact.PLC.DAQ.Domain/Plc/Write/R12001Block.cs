namespace Refact.PLC.DAQ.Domain.Plc.Write;

/// <summary>
/// R12001 ?Œë“œ. ?‘ë‹µ/?íƒœ ? í˜¸. (ushort[] index 0)
/// </summary>
public class R12001Block : PlcWriteBlockBase
{
    public enum Bits
    {
        Ok = 0,
        Ng = 1,
        SerialKey = 2,
        Heartbeat = 3
    }

    public R12001Block(PlcWriteBuffer buffer, int wordIndex) : base(buffer, wordIndex)
    {
    }

    public void SetOk() => SetBit((int)Bits.Ok, 1);
    public void ClearOk() => SetBit((int)Bits.Ok, 0);
    public void SetNg() => SetBit((int)Bits.Ng, 1);
    public void ClearNg() => SetBit((int)Bits.Ng, 0);
    public void SetSerialKey(bool on) => SetBit((int)Bits.SerialKey, (ushort)(on ? 1 : 0));
    public void SetHeartbeat(bool on) => SetBit((int)Bits.Heartbeat, (ushort)(on ? 1 : 0));
}
