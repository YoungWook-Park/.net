using System.Collections.ObjectModel;
using Refact.PLC.DAQ.Domain.TestDriver;

namespace Refact.PLC.DAQ.Wpf.TestDriver;

/// <summary>
/// ITraceSink implementation that appends to an ObservableCollection for UI binding.
/// </summary>
public class TraceSink : ITraceSink
{
    public ObservableCollection<string> Lines { get; } = new();

    public void Log(string message)
    {
        var line = $"[{DateTime.Now:HH:mm:ss.fff}] {message}";
        App.Current.Dispatcher.Invoke(() => Lines.Add(line));
    }

    public void Clear()
    {
        Lines.Clear();
    }
}
