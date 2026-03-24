namespace Refact.PLC.DAQ.Domain.Plc.Write;

/// <summary>
/// R12004 ?Œë“œ. (ushort[] index 3)
/// </summary>
public class R12004Block : PlcWriteBlockBase
{
    public R12004Block(PlcWriteBuffer buffer, int wordIndex) : base(buffer, wordIndex)
    {
    }

    public void SetValue(ushort value) => SetWord(value);
}
