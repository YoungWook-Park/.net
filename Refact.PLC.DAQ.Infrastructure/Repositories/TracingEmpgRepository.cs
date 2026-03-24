using Refact.PLC.DAQ.Domain.Dtos;
using Refact.PLC.DAQ.Domain.TestDriver;
using Refact.PLC.DAQ.Infrastructure.Data;

namespace Refact.PLC.DAQ.Infrastructure.Repositories;

/// <summary>
/// EmpgRepository ?ÅÏÜç. DB Ï≤òÎ¶¨ Î°úÍ∑∏Î•?TestDriver??Ï∂úÎ†•.
/// </summary>
public class TracingEmpgRepository : EmpgRepository
{
    private readonly ITraceSink _trace;

    public TracingEmpgRepository(DongboDaqDbContext db, ITraceSink trace)
        : base(db)
    {
        _trace = trace;
    }

    public override async Task InsertAsync(Op100EmpgInsertDto dto, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] InsertAsync(Op100) ?úÏûë: RESULT_ID={dto.ResultId}, MODEL={dto.Model}");
        await base.InsertAsync(dto, ct);
        _trace.Log($"[EmpgRepository] InsertAsync(Op100) ?ÑÎ£å: RESULT_ID={dto.ResultId}");
    }

    public override async Task InsertAsync(Op200EmpgInsertDto dto, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] InsertAsync(Op200) ?úÏûë: RESULT_ID={dto.ResultId}, MODEL={dto.Model}");
        await base.InsertAsync(dto, ct);
        _trace.Log($"[EmpgRepository] InsertAsync(Op200) ?ÑÎ£å: RESULT_ID={dto.ResultId}");
    }

    public override async Task InsertAsync(Op210EmpgInsertDto dto, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] InsertAsync(Op210) ?úÏûë: RESULT_ID={dto.ResultId}, MatSerial01={dto.MatSerial01}");
        await base.InsertAsync(dto, ct);
        _trace.Log($"[EmpgRepository] InsertAsync(Op210) ?ÑÎ£å: RESULT_ID={dto.ResultId}");
    }

    public override async Task InsertAsync(Op220EmpgInsertDto dto, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] InsertAsync(Op220) ?úÏûë: RESULT_ID={dto.ResultId}, MatSerial01={dto.MatSerial01}");
        await base.InsertAsync(dto, ct);
        _trace.Log($"[EmpgRepository] InsertAsync(Op220) ?ÑÎ£å: RESULT_ID={dto.ResultId}");
    }

    public override async Task InsertAsync(Op230EmpgInsertDto dto, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] InsertAsync(Op230) ?úÏûë: RESULT_ID={dto.ResultId}, MatSerial01={dto.MatSerial01}");
        await base.InsertAsync(dto, ct);
        _trace.Log($"[EmpgRepository] InsertAsync(Op230) ?ÑÎ£å: RESULT_ID={dto.ResultId}");
    }

    public override async Task UpdateAsync(string resultId, Op210EmpgUpdateDto dto, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] UpdateAsync(Op210) ?úÏûë: RESULT_ID={resultId}");
        await base.UpdateAsync(resultId, dto, ct);
        _trace.Log($"[EmpgRepository] UpdateAsync(Op210) ?ÑÎ£å: RESULT_ID={resultId}");
    }

    public override async Task UpdateAsync(string resultId, Op220EmpgUpdateDto dto, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] UpdateAsync(Op220) ?úÏûë: RESULT_ID={resultId}");
        await base.UpdateAsync(resultId, dto, ct);
        _trace.Log($"[EmpgRepository] UpdateAsync(Op220) ?ÑÎ£å: RESULT_ID={resultId}");
    }

    public override async Task UpdateAsync(string resultId, Op230EmpgUpdateDto dto, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] UpdateAsync(Op230) ?úÏûë: RESULT_ID={resultId}");
        await base.UpdateAsync(resultId, dto, ct);
        _trace.Log($"[EmpgRepository] UpdateAsync(Op230) ?ÑÎ£å: RESULT_ID={resultId}");
    }

    public override async Task<EmpgRowDto?> FindByMatSerial01Async(string matSerial01, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] FindByMatSerial01Async: MatSerial01={matSerial01}");
        var result = await base.FindByMatSerial01Async(matSerial01, ct);
        _trace.Log(result != null
            ? $"[EmpgRepository] FindByMatSerial01 Í≤∞Í≥º: Í∏∞Ï°¥ ???àÏùå RESULT_ID={result.ResultId}"
            : "[EmpgRepository] FindByMatSerial01 Í≤∞Í≥º: Í∏∞Ï°¥ ???ÜÏùå");
        return result;
    }

    public override async Task<EmpgRowDto?> FindByMatSerial02Async(string matSerial02, CancellationToken ct = default)
    {
        _trace.Log($"[EmpgRepository] FindByMatSerial02Async: MatSerial02={matSerial02}");
        var result = await base.FindByMatSerial02Async(matSerial02, ct);
        _trace.Log(result != null
            ? $"[EmpgRepository] FindByMatSerial02 Í≤∞Í≥º: Í∏∞Ï°¥ ???àÏùå RESULT_ID={result.ResultId}"
            : "[EmpgRepository] FindByMatSerial02 Í≤∞Í≥º: Í∏∞Ï°¥ ???ÜÏùå");
        return result;
    }
}
