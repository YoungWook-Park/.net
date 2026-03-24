using System.Windows;

namespace Refact.PLC.DAQ.Wpf.Services;

/// <summary>
/// IOpenWindowService implementation. Opens TestDriverWindow and others.
/// </summary>
public class OpenWindowService : IOpenWindowService
{
    public void OpenTestDriver()
    {
        var window = new TestDriver.TestDriverWindow();
        window.Owner = Application.Current.MainWindow;
        window.Show();
    }
}
