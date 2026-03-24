using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Refact.PLC.DAQ.Domain.Handlers;
using Refact.PLC.DAQ.Domain.Plc;
using Refact.PLC.DAQ.Domain.TestDriver;
using Refact.PLC.DAQ.Infrastructure.Plc;
using Refact.PLC.DAQ.WpfCommon;

namespace Refact.PLC.DAQ.Wpf.TestDriver;

/// <summary>
/// ViewModel for TestDriverWindow.
/// </summary>
public class TestDriverWindowViewModel : NotifyPropertyChangedBase
{
    #region Variable

    private readonly IServiceProvider _serviceProvider;
    private readonly ITraceSink _traceSink;
    private AsyncRelayCommand? _runCommand;
    private bool _isRunning;

    #endregion

    #region Constructor

    public TestDriverWindowViewModel(IServiceProvider serviceProvider, ITraceSink traceSink)
    {
        _serviceProvider = serviceProvider;
        _traceSink = traceSink;
    }

    #endregion

    #region Property

    /// <summary>
    /// Log lines for binding.
    /// </summary>
    public ObservableCollection<string> Lines => _traceSink.Lines;

    /// <summary>
    /// True while RunCommand is executing.
    /// </summary>
    public bool IsRunning
    {
        get => _isRunning;
        private set => SetProperty(ref _isRunning, value);
    }

    public ICommand RunCommand =>
        _runCommand ??= new AsyncRelayCommand(PerformRun, () => !IsRunning);

    #endregion

    #region UI Function

    private async Task PerformRun()
    {
        _traceSink.Clear();
        _traceSink.Log("1. Preparing Backup_Start word (index 0)=1 simulation...");

        using var scope = _serviceProvider.CreateScope();
        var plcDevice = scope.ServiceProvider.GetRequiredService<FakePlcDevice>();
        var handler = scope.ServiceProvider.GetRequiredService<IProcessDataHandler>();

        var processData = CreateOp100ProcessData();
        var settingData = CreateOp100SettingData();

        plcDevice.SetProcessData(PlcBlockKey.OP100_ProcessData, processData);
        plcDevice.SetSettingData(PlcBlockKey.OP100_SettingData, settingData);

        _traceSink.Log("2. PLC data set (Backup_Start=1, Model=AB, Serial=SH/GR)");
        _traceSink.Log("3. HandleOp100Async() ??Parser ??Mapper ??DB");

        IsRunning = true;
        try
        {
            await handler.HandleOp100Async();
            _traceSink.Log("4. DB processing complete.");
        }
        catch (Exception ex)
        {
            _traceSink.Log($"Error: {ex.Message}");
            _traceSink.Log(ex.StackTrace ?? string.Empty);
        }
        finally
        {
            IsRunning = false;
        }
    }

    #endregion

    #region Function

    private static short[] CreateOp100ProcessData()
    {
        var data = new short[TestDriverConstants.ProcessDataLength];
        data[TestDriverConstants.IndexBackupStart] = TestDriverConstants.IndexBackupStartValue;
        data[TestDriverConstants.IndexBackupStartAux] = 0;
        data[TestDriverConstants.IndexModel1] = 65; // 'A'
        data[TestDriverConstants.IndexModel2] = 66; // 'B'
        data[TestDriverConstants.IndexSerial1] = 83; // 'S'
        data[TestDriverConstants.IndexSerial2] = 72; // 'H'
        data[TestDriverConstants.IndexSerial3] = 71; // 'G'
        data[TestDriverConstants.IndexSerial4] = 82; // 'R'
        data[TestDriverConstants.IndexJudge] = 1;
        data[TestDriverConstants.IndexJudgeValue] = 1234;
        data[TestDriverConstants.IndexTotalJudge] = 1;
        data[TestDriverConstants.IndexProductionQty] = 1;
        return data;
    }

    private static short[] CreateOp100SettingData()
    {
        var data = new short[TestDriverConstants.SettingDataLength];
        for (var i = 0; i < data.Length; i++)
        {
            data[i] = TestDriverConstants.SettingDataDefault;
        }

        return data;
    }

    #endregion
}
