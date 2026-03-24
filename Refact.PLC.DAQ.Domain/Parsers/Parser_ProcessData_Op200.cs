using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Domain.Parsers;

public static class Parser_ProcessData_Op200
{
    /// <summary>
    /// Parses PLC process data. Returns parsed result or null on failure.
    /// Object is created first, then returned for easier debugging.
    /// </summary>
    public static Op200ProcessParsed? Parse(short[] in_ReceiveData)
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

            floatCalVal = (double)in_ReceiveData[72] / 100;
            var apd09 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 73) / 100;
            var apd10 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[75] / 100;
            var apd11 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 76) / 100;
            var apd12 = floatCalVal.ToString("0.00");

            floatCalVal = (double)in_ReceiveData[78] / 100;
            var apd13 = floatCalVal.ToString("0.00");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 79) / 100;
            var apd14 = floatCalVal.ToString("0.00");

            var apd15 = in_ReceiveData[81] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[81].ToString()
            };

            var apd16 = in_ReceiveData[82].ToString();

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 83) / 10000;
            var apd17 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 85) / 10000;
            var apd18 = floatCalVal.ToString("0.0000");

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 87) / 100;
            var apd19 = floatCalVal.ToString("0.00");

            var apd20 = in_ReceiveData[89].ToString();

            var apd21 = in_ReceiveData[90] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[90].ToString()
            };

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 91) / 100;
            var apd22 = floatCalVal.ToString("0.00");

            var apd23 = in_ReceiveData[93] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[93].ToString()
            };

            var apd24 = in_ReceiveData[94] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[94].ToString()
            };

            floatCalVal = (double)PlcDataConverter.ShortToInt(in_ReceiveData, 95) / 100;
            var apd25 = floatCalVal.ToString("0.00");

            var apd26 = in_ReceiveData[97] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[97].ToString()
            };

            var result = new Op200ProcessParsed(
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
                Apd10: apd10,
                Apd11: apd11,
                Apd12: apd12,
                Apd13: apd13,
                Apd14: apd14,
                Apd15: apd15,
                Apd16: apd16,
                Apd17: apd17,
                Apd18: apd18,
                Apd19: apd19,
                Apd20: apd20,
                Apd21: apd21,
                Apd22: apd22,
                Apd23: apd23,
                Apd24: apd24,
                Apd25: apd25,
                Apd26: apd26
            );

            return result;
        }
        catch
        {
            return null;
        }
    }
}
