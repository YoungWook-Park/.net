using System.Windows.Input;

namespace Refact.PLC.DAQ.WpfCommon;

/// <summary>
/// ICommand implementation based on Action. Executes without parameter.
/// </summary>
public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

    public void Execute(object? parameter) => _execute();

    /// <summary>
    /// Forces CanExecute to be re-evaluated.
    /// </summary>
    public static void InvalidateRequerySuggested()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}
