namespace Refact.PLC.DAQ.Domain.Plc.Write;

/// <summary>
/// PLC Write ?Œë“œ ë¸”ë¡ ë² ì´?? WordIndex???ì„±?ì—??ê³ ì •.
/// </summary>
public abstract class PlcWriteBlockBase
{
    private readonly PlcWriteBuffer _buffer;
    private readonly int _wordIndex;

    protected PlcWriteBlockBase(PlcWriteBuffer buffer, int wordIndex)
    {
        _buffer = buffer;
        _wordIndex = wordIndex;
    }

    /// <summary>
    /// ë¹„íŠ¸ ?¤ì •. bitIndex???´ê±°?•ì„ (int)ë¡?ìºìŠ¤?…í•˜???„ë‹¬.
    /// </summary>
    /// <param name="bitIndex">ë¹„íŠ¸ ?¸ë±??(0~15). ?´ë‹¹ ë¸”ë¡??Bits enum ?¬ìš©.</param>
    /// <param name="value">0=?´ì œ, ê·????¤ì •.</param>
    protected void SetBit(int bitIndex, ushort value)
    {
        _buffer.SetBit(_wordIndex, bitIndex, value);
    }

    /// <summary>
    /// ?Œë“œ ?„ì²´ ê°??¤ì •. WordIndex??ë¸”ë¡??ê³ ì •?˜ì–´ ?ˆìŒ.
    /// </summary>
    protected void SetWord(ushort value)
    {
        _buffer.SetWord(_wordIndex, value);
    }
}
