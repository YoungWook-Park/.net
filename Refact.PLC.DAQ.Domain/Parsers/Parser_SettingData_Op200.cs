using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Domain.Parsers;

public static class Parser_SettingData_Op200
{
    /// <summary>
    /// Parses PLC setting data. Returns parsed result or null on failure.
    /// Object is created first, then returned for easier debugging.
    /// Used by Op200, Op210 (Sp31-36), Op220 (Sp35-36 as Sp37-38).
    /// </summary>
    public static Op200SettingParsed? Parse(short[] in_ReceiveData)
    {
        if (in_ReceiveData == null)
            throw new ArgumentNullException(nameof(in_ReceiveData));

        try
        {
            var floatCalVal = (double)in_ReceiveData[0] / 100;
            var sp01 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[1] / 100;
            var sp02 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 2) / 100;
            var sp03 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 4) / 100;
            var sp04 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[6] / 100;
            var sp05 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[7] / 100;
            var sp06 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 8) / 100;
            var sp07 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 10) / 100;
            var sp08 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[12] / 100;
            var sp09 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[13] / 100;
            var sp10 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 14) / 100;
            var sp11 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 16) / 100;
            var sp12 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[20] / 100;
            var sp13 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[21] / 100;
            var sp14 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 22) / 100;
            var sp15 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 24) / 100;
            var sp16 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[26] / 100;
            var sp17 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[27] / 100;
            var sp18 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 28) / 100;
            var sp19 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 30) / 100;
            var sp20 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[32] / 100;
            var sp21 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[33] / 100;
            var sp22 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 34) / 100;
            var sp23 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 36) / 100;
            var sp24 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 48) / 10000;
            var sp25 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 50) / 10000;
            var sp26 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 52) / 10000;
            var sp27 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 54) / 10000;
            var sp28 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 60) / 10000;
            var sp29 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 62) / 10000;
            var sp30 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 70) / 100;
            var sp31 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 72) / 100;
            var sp32 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 74) / 10000;
            var sp33 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 76) / 10000;
            var sp34 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 80) / 10000;
            var sp35 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 82) / 10000;
            var sp36 = floatCalVal.ToString("0.0000");

            var result = new Op200SettingParsed(
                Sp01: sp01,
                Sp02: sp02,
                Sp03: sp03,
                Sp04: sp04,
                Sp05: sp05,
                Sp06: sp06,
                Sp07: sp07,
                Sp08: sp08,
                Sp09: sp09,
                Sp10: sp10,
                Sp11: sp11,
                Sp12: sp12,
                Sp13: sp13,
                Sp14: sp14,
                Sp15: sp15,
                Sp16: sp16,
                Sp17: sp17,
                Sp18: sp18,
                Sp19: sp19,
                Sp20: sp20,
                Sp21: sp21,
                Sp22: sp22,
                Sp23: sp23,
                Sp24: sp24,
                Sp25: sp25,
                Sp26: sp26,
                Sp27: sp27,
                Sp28: sp28,
                Sp29: sp29,
                Sp30: sp30,
                Sp31: sp31,
                Sp32: sp32,
                Sp33: sp33,
                Sp34: sp34,
                Sp35: sp35,
                Sp36: sp36
            );

            return result;
        }
        catch
        {
            return null;
        }
    }
}
