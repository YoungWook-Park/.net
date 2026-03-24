# Refact_PLC_DAQ

PLC DAQ application built with .NET 8, WPF, and Entity Framework Core.

## Structure

- **Refact.PLC.DAQ.Domain** – Domain models, DTOs, parsers, PLC definitions
- **Refact.PLC.DAQ.Infrastructure** – DB, PLC implementations, handlers, orchestration
- **Refact.PLC.DAQ.Wpf** – WPF UI (MVVM)
- **Refact.PLC.DAQ.WpfCommon** – MVVM base classes (NotifyPropertyChangedBase, RelayCommand, etc.)
- **Refact.PLC.DAQ.Tests** – Unit tests

## Requirements

- .NET 8
- SQL Server (connection string in `appsettings.json`)
- Windows (WPF)

## Build & Run

```bash
dotnet build Refact_PLC_DAQ.sln
dotnet run --project Refact.PLC.DAQ.Wpf
```

## Test Driver

The WPF app includes a Test Driver that simulates PLC data and runs the HandleOp100Async pipeline against a real database.
