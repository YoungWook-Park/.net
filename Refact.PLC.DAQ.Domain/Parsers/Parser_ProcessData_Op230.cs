using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Domain.Parsers;

public static class Parser_ProcessData_Op230
{
    /// <summary>
    /// Parses PLC process data. Returns parsed result or null on failure.
    /// Object is created first, then returned for easier debugging.
    /// </summary>
    public static Op230ProcessParsed? Parse(short[] in_ReceiveData)
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

            var serialNo01 = PlcDataConverter.ShortToString(in_ReceiveData, 20, 20);
            var matSerial01 = string.IsNullOrWhiteSpace(serialNo01) ? string.Empty : serialNo01;

            var serialNo02 = PlcDataConverter.ShortToString(in_ReceiveData, 40, 20);
            var matSerial02 = string.IsNullOrWhiteSpace(serialNo02) ? string.Empty : serialNo02;

            var apd35 = in_ReceiveData[60] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[60].ToString()
            };

            var apd36 = in_ReceiveData[61] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[61].ToString()
            };

            var floatCalVal = (double)in_ReceiveData[62] / 100;
            var apd37 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 63) / 100;
            var apd38 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[65] / 100;
            var apd39 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 66) / 100;
            var apd40 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[68] / 100;
            var apd41 = floatCalVal.ToString("0.00");

            var apd42 = in_ReceiveData[71] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[71].ToString()
            };

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 72) / 10000;
            var apd43 = floatCalVal.ToString("0.0000");

            var apd44 = in_ReceiveData[74] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[74].ToString()
            };

            var totalJudge = apd35;

            var result = new Op230ProcessParsed(
                Repair: repair,
                Model: model,
                MatSerial01: matSerial01,
                MatSerial02: matSerial02,
                TotalJudge: totalJudge,
                Apd35: apd35,
                Apd36: apd36,
                Apd37: apd37,
                Apd38: apd38,
                Apd39: apd39,
                Apd40: apd40,
                Apd41: apd41,
                Apd42: apd42,
                Apd43: apd43,
                Apd44: apd44
            );

            return result;
        }
        catch
        {
            return null;
        }
    }
}
