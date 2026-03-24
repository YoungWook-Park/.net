using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Domain.Parsers;

public static class Parser_SettingData_Op230
{
    /// <summary>
    /// Parses PLC setting data. Returns parsed result or null on failure.
    /// Object is created first, then returned for easier debugging.
    /// </summary>
    public static Op230SettingParsed? Parse(short[] in_ReceiveData)
    {
        if (in_ReceiveData == null)
            throw new ArgumentNullException(nameof(in_ReceiveData));

        try
        {
            var floatCalVal = (double)in_ReceiveData[0] / 100;
            var sp39 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[1] / 100;
            var sp40 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 2) / 100;
            var sp41 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 4) / 100;
            var sp42 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[6] / 100;
            var sp43 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[7] / 100;
            var sp44 = floatCalVal.ToString("0.00");

            var result = new Op230SettingParsed(
                Sp39: sp39,
                Sp40: sp40,
                Sp41: sp41,
                Sp42: sp42,
                Sp43: sp43,
                Sp44: sp44
            );

            return result;
        }
        catch
        {
            return null;
        }
    }
}
