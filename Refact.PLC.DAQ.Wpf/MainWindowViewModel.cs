using System.Windows.Input;
using Microsoft.Extensions.Logging;
using Refact.PLC.DAQ.WpfCommon;
using Refact.PLC.DAQ.Wpf.Services;

namespace Refact.PLC.DAQ.Wpf;

/// <summary>
/// ViewModel for MainWindow.
/// </summary>
public class MainWindowViewModel : NotifyPropertyChangedBase
{
    #region Variable

    private readonly IOpenWindowService _openWindowService;
    private readonly ILogger<MainWindowViewModel> _logger;
    private RelayCommand? _openTestDriverCommand;

    #endregion

    #region Constructor

    public MainWindowViewModel(IOpenWindowService openWindowService, ILogger<MainWindowViewModel> logger)
    {
        _openWindowService = openWindowService;
        _logger = logger;
    }

    #endregion

    #region Property

    public ICommand OpenTestDriverCommand =>
        _openTestDriverCommand ??= new RelayCommand(() => PerformOpenTestDriver(null));

    #endregion

    #region UI Function

    private void PerformOpenTestDriver(object? commandParameter)
    {
        try
        {
            _openWindowService.OpenTestDriver();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to open test driver");
        }
    }

    #endregion
}
