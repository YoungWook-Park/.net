using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Domain.Parsers;

public static class Parser_ProcessData_Op210
{
    /// <summary>
    /// Parses PLC process data. Returns parsed result or null on failure.
    /// Object is created first, then returned for easier debugging.
    /// </summary>
    public static Op210ProcessParsed? Parse(short[] in_ReceiveData)
    {
        if (in_ReceiveData == null)
            throw new ArgumentNullException(nameof(in_ReceiveData));

        try
        {
            var repair = in_ReceiveData[2] switch
            {
                0 => DbRepairCode.AUTO,
                1 => DbRepairCode.REPAIR,
                2 => DbRepairCode.MASTER,
                _ => in_ReceiveData[2].ToString()
            };

            var model = PlcDataConverter.ShortToString(in_ReceiveData, 10, 10);

            var serialNo = PlcDataConverter.ShortToString(in_ReceiveData, 20, 20);
            var matSerial01 = string.IsNullOrWhiteSpace(serialNo) ? string.Empty : serialNo;

            var totalJudge = in_ReceiveData[62] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[62].ToString()
            };

            var floatCalVal = (double)in_ReceiveData[60] / 10000;
            var apd27 = floatCalVal.ToString("0.0000");

            var apd28 = in_ReceiveData[62] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[62].ToString()
            };

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 63) / 10000;
            var apd29 = floatCalVal.ToString("0.0000");

            var apd30 = in_ReceiveData[65] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[65].ToString()
            };

            var result = new Op210ProcessParsed(
                Repair: repair,
                Model: model,
                MatSerial01: matSerial01,
                TotalJudge: totalJudge,
                Apd27: apd27,
                Apd28: apd28,
                Apd29: apd29,
                Apd30: apd30
            );

            return result;
        }
        catch
        {
            return null;
        }
    }
}
