namespace Refact.PLC.DAQ.Domain.Plc;

/// <summary>
/// Constants for PLC block/device keys. Aligns with legacy DeviceKey (PC_Read_OP*).
/// </summary>
public static class PlcBlockKey
{
    public const string OP100_ProcessData = "PC_Read_OP100_ProcessData";
    public const string OP100_SettingData = "PC_Read_OP100_SettingData";
    public const string OP200_ProcessData = "PC_Read_OP200_ProcessData";
    public const string OP200_SettingData = "PC_Read_OP200_SettingData";
    public const string OP210_ProcessData = "PC_Read_OP210_ProcessData";
    public const string OP220_ProcessData = "PC_Read_OP220_ProcessData";
    public const string OP230_ProcessData = "PC_Read_OP230_ProcessData";
    public const string OP230_SettingData = "PC_Read_OP230_SettingData";
}
