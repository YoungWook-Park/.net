using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Domain.Parsers;

public static class Parser_SettingData_Op100
{
    /// <summary>
    /// Parses PLC setting data. Returns parsed result or null on failure.
    /// Object is created first, then returned for easier debugging.
    /// </summary>
    public static Op100SettingParsed? Parse(short[] in_ReceiveData)
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

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 20) / 10000;
            var sp13 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 22) / 10000;
            var sp14 = floatCalVal.ToString("0.0000");

            var result = new Op100SettingParsed(
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
                Sp14: sp14
            );

            return result;
        }
        catch
        {
            return null;
        }
    }
}
