using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Domain.Parsers;

public static class Parser_ProcessData_Op100
{
    /// <summary>
    /// Parses PLC process data. Returns parsed result or null on failure.
    /// Object is created first, then returned for easier debugging.
    /// </summary>
    public static Op100ProcessParsed? Parse(short[] in_ReceiveData)
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

            serialNo = PlcDataConverter.ShortToString(in_ReceiveData, 40, 20);
            var matSerial02 = string.IsNullOrWhiteSpace(serialNo) ? string.Empty : serialNo;

            var totalJudge = in_ReceiveData[60] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[60].ToString()
            };

            var floatCalVal = (double)in_ReceiveData[61] / 100;
            var apd01 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 62) / 100;
            var apd02 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[64] / 100;
            var apd03 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 65) / 100;
            var apd04 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[67] / 100;
            var apd05 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 68) / 100;
            var apd06 = floatCalVal.ToString("0.00");

            var apd07 = in_ReceiveData[70] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[70].ToString()
            };

            var apd08 = in_ReceiveData[71].ToString();

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 72) / 10000;
            var apd09 = floatCalVal.ToString("0.0000");

            var apd10 = in_ReceiveData[74] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[74].ToString()
            };

            var result = new Op100ProcessParsed(
                Repair: repair,
                Model: model,
                MatSerial01: matSerial01,
                MatSerial02: matSerial02,
                TotalJudge: totalJudge,
                Apd01: apd01,
                Apd02: apd02,
                Apd03: apd03,
                Apd04: apd04,
                Apd05: apd05,
                Apd06: apd06,
                Apd07: apd07,
                Apd08: apd08,
                Apd09: apd09,
                Apd10: apd10
            );

            return result;
        }
        catch
        {
            return null;
        }
    }
}
