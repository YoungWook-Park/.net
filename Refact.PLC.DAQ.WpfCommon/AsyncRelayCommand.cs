using System.Windows.Input;

namespace Refact.PLC.DAQ.WpfCommon;

/// <summary>
/// Func&lt;Task&gt; 기반 비동�?ICommand 구현.
/// </summary>
public class AsyncRelayCommand : ICommand
{
    private readonly Func<Task> _execute;
    private readonly Func<bool>? _canExecute;
    private bool _isExecuting;

    public AsyncRelayCommand(Func<Task> execute, Func<bool>? canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        if (_isExecuting)
            return false;
        return _canExecute?.Invoke() ?? true;
    }

    public void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
            return;

        _ = ExecuteAsync();
    }

    private async Task ExecuteAsync()
    {
        _isExecuting = true;
        RaiseCanExecuteChanged();

        try
        {
            await _execute();
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    private void RaiseCanExecuteChanged()
    {
        CommandManager.InvalidateRequerySuggested();
    }
}
