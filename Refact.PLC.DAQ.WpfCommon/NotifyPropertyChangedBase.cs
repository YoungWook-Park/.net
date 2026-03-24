using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Refact.PLC.DAQ.WpfCommon;

/// <summary>
/// Base implementation of INotifyPropertyChanged. For ViewModel inheritance.
/// </summary>
public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Sets the field and raises PropertyChanged when the value changes.
    /// </summary>
    /// <param name="field">Backing field ref.</param>
    /// <param name="value">Value to set.</param>
    /// <param name="propertyName">Property name (auto via CallerMemberName).</param>
    /// <returns>True if the value changed.</returns>
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    /// <summary>
    /// Raises the PropertyChanged event.
    /// </summary>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
