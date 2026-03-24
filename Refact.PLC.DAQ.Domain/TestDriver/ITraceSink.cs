using System.Collections.ObjectModel;

namespace Refact.PLC.DAQ.Domain.TestDriver;

/// <summary>
/// Sink for test driver trace messages. Used to display DB processing flow in UI.
/// </summary>
public interface ITraceSink
{
    void Log(string message);
    void Clear();
    ObservableCollection<string> Lines { get; }
}
