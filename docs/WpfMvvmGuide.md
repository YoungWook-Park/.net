# WPF MVVM Implementation Guide

A development guide for applying the MVVM pattern in WPF projects.

---

## 1. MVVM Basics

- **View** (`*View.xaml` / `*Window.xaml`): UI, layout, and bindings only. No business logic.
- **ViewModel**: State, commands, and logic required for the UI. Does not depend on View directly.
- **Model/Service**: Data access, device access, domain logic.

---

## 2. ViewModel Structure (Recommended)

Organizing by `#region` improves readability. Recommended order:

| Order | Region | Content |
|-------|--------|---------|
| 1 | `#region Variable` | Private fields (backing fields, dependency references, etc.) |
| 2 | `#region Constructor` | Constructor |
| 3 | `#region Property` | Public properties (including commands) |
| 4 | `#region Function` | Non-command methods (load, refresh, async helpers, etc.) |
| 5 | `#region UI Function` | Command pattern: private field, public ICommand, Perform method |

---

## 3. Command Pattern

### Example

```csharp
// Private field
private RelayCommand? _openTestDriverCommand;

// Public property
public ICommand OpenTestDriverCommand =>
    _openTestDriverCommand ??= new RelayCommand(PerformOpenTestDriver);

// Handler (try/catch/finally recommended)
private void PerformOpenTestDriver(object? parameter)
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
```

### Choosing a Command Implementation

| Use Case | Type | Examples |
|----------|------|----------|
| Simple execution | `RelayCommand` | Open window, apply settings |
| Parameter passing | `DelegateCommand` | List item selection, CommandParameter |
| Async execution | `AsyncRelayCommand` | DB processing, PLC communication |

### Naming

- Command property: `{Action}Command` (e.g. `OpenTestDriverCommand`, `RunCommand`)
- Handler method: `Perform{Action}` or `Execute{Action}` (e.g. `PerformOpenTestDriver`)

---

## 4. Async Command

Use async commands for long-running IO or device operations.

```csharp
public ICommand RunCommand =>
    _runCommand ??= new AsyncRelayCommand(RunAsync, () => !IsRunning);

private async Task RunAsync()
{
    IsRunning = true;
    try
    {
        await _handler.HandleOp100Async();
    }
    catch (Exception ex)
    {
        _traceSink.Log($"Error: {ex.Message}");
    }
    finally
    {
        IsRunning = false;
    }
}
```

---

## 5. Folder Structure (Recommended)

Place each ViewModel next to its View. Use feature-based subfolders.

```
MainWindow.xaml
MainWindow.xaml.cs
MainWindowViewModel.cs

TestDriver/
  TestDriverWindow.xaml
  TestDriverWindow.xaml.cs
  TestDriverWindowViewModel.cs
```

- Do not use a separate `ViewModels/` folder
- Use feature subfolders (e.g. `TestDriver/`, `Setting/`) when grouping related views

---

## 6. Naming (Optional)

Sequence/domain class naming: `{LevelOrDomain}_{Feature}_{Detail}`

Examples: `Manual_Axis1_V_Stop`, `Auto_Process_Start`

---

## 7. View–ViewModel Naming and Location

ViewModel class and file must match the View name. Place the ViewModel file in the **same folder** as the View.

| View | ViewModel (same folder) |
|------|-------------------------|
| `MainWindow.xaml` | `MainWindowViewModel.cs` |
| `TestDriverWindow.xaml` | `TestDriverWindowViewModel.cs` |
| `SettingLabJack_View.xaml` | `SettingLabJack_ViewModel.cs` |

- Pattern: `{ViewName}ViewModel`
- No separate `ViewModels/` folder — co-locate View and ViewModel

---

## 8. DataContext Wiring

- Inject ViewModel via DI and assign to DataContext when creating the View
- Minimize code-behind (initialization, close events, etc.)

---

## 9. Notes

- Do not perform long-running IO or device work on the UI thread; use async patterns
- Log exceptions in command handlers, then surface them to the user
- ViewModel does not reference View types directly; abstract via service or interface
