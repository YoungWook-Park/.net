using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Domain.Parsed;
using Refact.PLC.DAQ.Domain.Plc;

namespace Refact.PLC.DAQ.Domain.Parsers;

public static class Parser_ProcessData_Op220
{
    /// <summary>
    /// Parses PLC process data. Returns parsed result or null on failure.
    /// Object is created first, then returned for easier debugging.
    /// </summary>
    public static Op220ProcessParsed? Parse(short[] in_ReceiveData)
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

            var totalJudge = in_ReceiveData[60] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[60].ToString()
            };

            var apd31 = totalJudge;

            var floatCalVal = (double)in_ReceiveData[61] / 10000;
            var apd32 = floatCalVal.ToString("0.0000");

            var apd33 = in_ReceiveData[63] switch
            {
                1 => DbJudgeCode.OK,
                2 => DbJudgeCode.NG,
                4 => DbJudgeCode.PASS,
                _ => in_ReceiveData[63].ToString()
            };

            var result = new Op220ProcessParsed(
                Repair: repair,
                Model: model,
                MatSerial01: matSerial01,
                TotalJudge: totalJudge,
                Apd31: apd31,
                Apd32: apd32,
                Apd33: apd33
            );

            return result;
        }
        catch
        {
            return null;
        }
    }
}
