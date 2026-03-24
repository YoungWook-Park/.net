namespace Refact.PLC.DAQ.Domain.Plc.Write;

/// <summary>
/// R12002 ?Œë“œ. (ushort[] index 1)
/// </summary>
public class R12002Block : PlcWriteBlockBase
{
    public R12002Block(PlcWriteBuffer buffer, int wordIndex) : base(buffer, wordIndex)
    {
    }

    public void SetValue(ushort value) => SetWord(value);
}
