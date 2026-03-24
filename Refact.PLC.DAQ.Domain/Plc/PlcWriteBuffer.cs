using System;
using Refact.PLC.DAQ.Domain.Plc.Write;

namespace Refact.PLC.DAQ.Domain.Plc;

/// <summary>
/// PLC Write ?ÅÏó≠(r12001~12005) Î≤ÑÌçº. ushort[5].
/// SetBit/SetWord???¥Î? ?ÑÏö©. Î∏îÎ°ù ?¥Îûò?§Î? ?µÌï¥ ?ëÍ∑º.
/// </summary>
public class PlcWriteBuffer
{
    public const int WriteWordCount = 5;

    private readonly ushort[] _words = new ushort[WriteWordCount];

    public R12001Block R12001 { get; }
    public R12002Block R12002 { get; }
    public R12003Block R12003 { get; }
    public R12004Block R12004 { get; }
    public R12005Block R12005 { get; }

    public PlcWriteBuffer()
    {
        R12001 = new R12001Block(this, 0);
        R12002 = new R12002Block(this, 1);
        R12003 = new R12003Block(this, 2);
        R12004 = new R12004Block(this, 3);
        R12005 = new R12005Block(this, 4);
    }

    /// <summary>
    /// Î∏îÎ°ù ?ÑÏö©. ÎπÑÌä∏ ?∞ÏÇ∞????Í≥≥Ïóê??Ï≤òÎ¶¨.
    /// </summary>
    internal void SetBit(int wordIndex, int bitIndex, ushort value)
    {
        var mask = (ushort)(1 << bitIndex);
        if (value != 0)
            _words[wordIndex] |= mask;
        else
            _words[wordIndex] &= (ushort)~mask;
    }

    /// <summary>
    /// Î∏îÎ°ù ?ÑÏö©. ?åÎìú ?ÑÏ≤¥ Í∞??§Ï†ï.
    /// </summary>
    internal void SetWord(int wordIndex, ushort value)
    {
        if (wordIndex < 0 || wordIndex >= _words.Length)
            throw new ArgumentOutOfRangeException(nameof(wordIndex));
        _words[wordIndex] = value;
    }

    /// <summary>
    /// ?ÑÏÜ°??Î∞∞Ïó¥ Î≥µÏÇ¨Î≥?Î∞òÌôò.
    /// </summary>
    public ushort[] Snapshot()
    {
        return (ushort[])_words.Clone();
    }
}
