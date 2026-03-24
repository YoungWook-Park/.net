# Changelog

All notable changes to this project are described here. Tags align with Git for blog/GitHub links.

## [v0.1-docs] - 2026-03-24

### Added

- `docs/` — WPF MVVM guide, shared C# rules, AI rules index (for blog / reference)
- Expanded `README.md` — snapshot, roadmap, doc links, suggested blog outline

### Already in tree (baseline for this tag)

- Solution rename to **Refact_PLC_DAQ** / **Refact.PLC.DAQ.*** projects
- MVVM: `MainWindowViewModel`, `TestDriverWindowViewModel`, `WpfCommon` commands
- `IPlcDevice` + `FakePlcDevice`, PLC write blocks R12001–R12005
- Test Driver → `HandleOp100Async` + DB
- Initial push to [YoungWook-Park/.net](https://github.com/YoungWook-Park/.net)

### Not done yet

- `DaqOrchestrator` not connected to WPF startup
- No TCP/external simulator yet

---

## How to tag (after commit)

```bash
git tag -a v0.1-docs -m "Documentation snapshot: README + docs/"
git push origin v0.1-docs
```
