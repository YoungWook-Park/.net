namespace Refact.PLC.DAQ.Domain.Plc.Write;

/// <summary>
/// R12003 ?Œë“œ. (ushort[] index 2)
/// </summary>
public class R12003Block : PlcWriteBlockBase
{
    public R12003Block(PlcWriteBuffer buffer, int wordIndex) : base(buffer, wordIndex)
    {
    }

    public void SetValue(ushort value) => SetWord(value);
}
