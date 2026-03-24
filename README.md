# Refact_PLC_DAQ

Personal toy project: PLC-oriented DAQ pipeline in **.NET 8**, **WPF (MVVM)**, **EF Core**, with a **Test Driver** that exercises `HandleOp100Async` against a real SQL Server database.

**Repository:** [github.com/YoungWook-Park/.net](https://github.com/YoungWook-Park/.net)

---

## Snapshot (what exists today)

| Area | Notes |
|------|--------|
| Solution | `Refact_PLC_DAQ.sln` |
| Namespaces | `Refact.PLC.DAQ.*` |
| PLC (dev) | `FakePlcDevice` implements `IPlcDevice` |
| UI | MVVM: `MainWindow` + `TestDriverWindow`, ViewModels co-located with views |
| Orchestration | `DaqOrchestrator` exists but is **not** started from the WPF host yet |

---

## Project structure

- **Refact.PLC.DAQ.Domain** – DTOs, parsers, PLC read/write definitions (`PlcWriteBuffer`, R12001–R12005 blocks)
- **Refact.PLC.DAQ.Infrastructure** – EF Core, repositories, `ProcessDataHandler`, `FakePlcDevice`, `DaqOrchestrator`
- **Refact.PLC.DAQ.Wpf** – WPF shell, Test Driver window, `IOpenWindowService`
- **Refact.PLC.DAQ.WpfCommon** – `NotifyPropertyChangedBase`, `RelayCommand`, `AsyncRelayCommand`, `DelegateCommand`
- **Refact.PLC.DAQ.Tests** – Unit/integration tests

---

## Requirements

- .NET 8
- Windows (WPF)
- SQL Server — connection string in `Refact.PLC.DAQ.Wpf/appsettings.json`

---

## Build & run

```bash
dotnet build Refact_PLC_DAQ.sln
dotnet run --project Refact.PLC.DAQ.Wpf
```

Run tests:

```bash
dotnet test Refact_PLC_DAQ.sln
```

---

## Documentation (`docs/`)

| File | Purpose |
|------|---------|
| [docs/WpfImplementation.md](docs/WpfImplementation.md) | Index of coding guides |
| [docs/WpfMvvmGuide.md](docs/WpfMvvmGuide.md) | MVVM, commands, View–ViewModel pairing |
| [docs/ConSightAIRules.md](docs/ConSightAIRules.md) | AI assistant conventions (optional) |
| [docs/CSharpSharedRules.md](docs/CSharpSharedRules.md) | Domain/Infrastructure C# rules |

Use these for **blog posts** or onboarding; keep them in sync when patterns change.

---

## Roadmap (ideas)

- [ ] Wire `DaqOrchestrator.RunAsync` from the app (background service / hosted loop)
- [ ] Replace or complement `FakePlcDevice` with **TCP** (or other) simulator ↔ host process
- [ ] Real PLC `IPlcDevice` implementation when hardware is available
- [ ] OP200/210/220/230 orchestration triggers (beyond OP100 Test Driver)

See [CHANGELOG.md](CHANGELOG.md) for version tags.

---

## Blog post outline (suggested)

1. **Refactor & structure** — rename to `Refact.PLC.DAQ`, layers, MVVM, GitHub push  
2. **Inter-process PLC simulation** — TCP (or gRPC) test app + `IPlcDevice` (future)

Tag releases in Git when you publish a post (e.g. `v0.1-docs`, `v0.2-tcp`).
