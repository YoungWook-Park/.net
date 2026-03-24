using Microsoft.EntityFrameworkCore;
using Refact.PLC.DAQ.Domain.Constants;
using Refact.PLC.DAQ.Infrastructure.Data;
using Refact.PLC.DAQ.Infrastructure.Entities;

namespace Refact.PLC.DAQ.Infrastructure.Repositories;

public class ModelRepository
{
    private readonly DongboDaqDbContext _db;

    public ModelRepository(DongboDaqDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// MODEL ??Upsert + TOTAL_JUDGE???�라 production_qty, finished_qty, defective_qty, yield 갱신.
    /// </summary>
    public virtual async Task UpsertAndUpdateCountsAsync(string model, string totalJudge, CancellationToken ct = default)
    {
        var existing = await _db.StsModel.FirstOrDefaultAsync(x => x.Model == model, ct);
        var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

        double prodQty;
        double finishedQty;
        double defectiveQty;
        double yield;

        if (existing != null)
        {
            prodQty = ParseDouble(existing.ProductionQty, 1);
            finishedQty = ParseDouble(existing.FinishedQty, 0);
            defectiveQty = ParseDouble(existing.DefectiveQty, 0);

            prodQty++;
            if (totalJudge == DbJudgeCode.OK)
                finishedQty++;
            else
                defectiveQty++;
            yield = prodQty > 0 ? finishedQty / prodQty : 0;

            existing.ProductionQty = prodQty.ToString();
            existing.FinishedQty = finishedQty.ToString();
            existing.DefectiveQty = defectiveQty.ToString();
            existing.Yield = yield.ToString("0.00");
            existing.UpdatedTime = now;
        }
        else
        {
            prodQty = 1;
            if (totalJudge == DbJudgeCode.OK)
            {
                finishedQty = 1;
                defectiveQty = 0;
            }
            else
            {
                finishedQty = 0;
                defectiveQty = 1;
            }
            yield = prodQty > 0 ? finishedQty / prodQty : 0;

            _db.StsModel.Add(new StsModelEntity
            {
                Model = model,
                ProductionQty = prodQty.ToString(),
                FinishedQty = finishedQty.ToString(),
                DefectiveQty = defectiveQty.ToString(),
                Yield = yield.ToString("0.00"),
                CreatedTime = now
            });
        }

        await _db.SaveChangesAsync(ct);
    }

    private static double ParseDouble(string? s, double defaultValue)
    {
        if (string.IsNullOrEmpty(s) || !double.TryParse(s, out var v))
            return defaultValue;
        return v;
    }
}
