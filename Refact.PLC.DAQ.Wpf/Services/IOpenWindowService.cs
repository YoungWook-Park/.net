namespace Refact.PLC.DAQ.Wpf.Services;

/// <summary>
/// Service to open windows. Allows ViewModel to open windows without depending on View types.
/// </summary>
public interface IOpenWindowService
{
    void OpenTestDriver();
}
