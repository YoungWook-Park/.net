using System.Windows.Input;

namespace Refact.PLC.DAQ.WpfCommon;

/// <summary>
/// Action&lt;object?&gt; 기반 ICommand 구현. CommandParameter ?�달.
/// </summary>
public class DelegateCommand : ICommand
{
    private readonly Action<object?> _execute;
    private readonly Predicate<object?>? _canExecute;

    public DelegateCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter) => _execute(parameter);

    /// <summary>
    /// CanExecute ?�태 ?�평가 강제.
    /// </summary>
    public static void InvalidateRequerySuggested()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}
