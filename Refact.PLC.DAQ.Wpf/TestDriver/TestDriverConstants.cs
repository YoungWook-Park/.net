namespace Refact.PLC.DAQ.Wpf.TestDriver;

/// <summary>
/// Constants for TestDriver OP100 simulation.
/// </summary>
public static class TestDriverConstants
{
    public const int ProcessDataLength = 80;
    public const int SettingDataLength = 24;
    public const short SettingDataDefault = 100;

    // Process data indices (OP100 layout)
    public const int IndexBackupStart = 0;
    public const int IndexBackupStartValue = 1;
    public const int IndexBackupStartAux = 2;
    public const int IndexModel1 = 10;
    public const int IndexModel2 = 11;
    public const int IndexSerial1 = 20;
    public const int IndexSerial2 = 21;
    public const int IndexSerial3 = 40;
    public const int IndexSerial4 = 41;
    public const int IndexJudge = 60;
    public const int IndexJudgeValue = 61;
    public const int IndexTotalJudge = 70;
    public const int IndexProductionQty = 74;
}
