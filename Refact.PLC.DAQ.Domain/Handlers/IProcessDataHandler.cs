namespace Refact.PLC.DAQ.Domain.Handlers;

/// <summary>
/// Orchestrates PLC read -> Parse -> Map -> Repository for each operation.
/// </summary>
public interface IProcessDataHandler
{
    Task HandleOp100Async(CancellationToken ct = default);
    Task HandleOp200Async(CancellationToken ct = default);
    Task HandleOp210Async(CancellationToken ct = default);
    Task HandleOp220Async(CancellationToken ct = default);
    Task HandleOp230Async(CancellationToken ct = default);
}
