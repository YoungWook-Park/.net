using Refact.PLC.DAQ.Domain.TestDriver;
using Refact.PLC.DAQ.Infrastructure.Data;

namespace Refact.PLC.DAQ.Infrastructure.Repositories;

/// <summary>
/// ModelRepository ?�속. DB 처리 로그�?TestDriver??출력.
/// </summary>
public class TracingModelRepository : ModelRepository
{
    private readonly ITraceSink _trace;

    public TracingModelRepository(DongboDaqDbContext db, ITraceSink trace)
        : base(db)
    {
        _trace = trace;
    }

    public override async Task UpsertAndUpdateCountsAsync(string model, string totalJudge, CancellationToken ct = default)
    {
        _trace.Log($"[ModelRepository] UpsertAndUpdateCountsAsync ?�작: MODEL={model}, TOTAL_JUDGE={totalJudge}");
        await base.UpsertAndUpdateCountsAsync(model, totalJudge, ct);
        _trace.Log($"[ModelRepository] UpsertAndUpdateCountsAsync ?�료: MODEL={model}");
    }
}
