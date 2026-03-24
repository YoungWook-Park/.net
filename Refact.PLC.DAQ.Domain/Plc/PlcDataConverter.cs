using System.Text;

namespace Refact.PLC.DAQ.Domain.Plc;

public static class PlcDataConverter
{
    public static string ShortToString(short[] data, int startIndex, int length)
    {
        var ret = string.Empty;

        for (var i = startIndex; i < startIndex + length && i < data.Length; i++)
        {
            var bytes = BitConverter.GetBytes(data[i]);
            foreach (var b in bytes)
            {
                if (b == 0x00) return ret;
                ret += (char)b;
            }
        }
        return ret.Trim();
    }

    public static int ShortToInt(short[] data, int startIndex)
    {
        if (data == null || startIndex + 1 >= data.Length) return 0;
        var high = (int)data[startIndex + 1] << 16;
        var low = data[startIndex] & 0xFFFF;
        return high | low;
    }

    public static bool JudgeBit(short data, int pos)
    {
        var cmp = (int)Math.Pow(2, pos);
        return (data & cmp) == cmp;
    }
}
