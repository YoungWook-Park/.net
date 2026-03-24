namespace Refact.PLC.DAQ.Domain.Plc.Write;

/// <summary>
/// R12005 ?Œë“œ. (ushort[] index 4)
/// </summary>
public class R12005Block : PlcWriteBlockBase
{
    public R12005Block(PlcWriteBuffer buffer, int wordIndex) : base(buffer, wordIndex)
    {
    }

    public void SetValue(ushort value) => SetWord(value);
}
