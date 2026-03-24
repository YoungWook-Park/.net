using Microsoft.EntityFrameworkCore;
using Refact.PLC.DAQ.Domain.Dtos;
using Refact.PLC.DAQ.Infrastructure.Data;
using Refact.PLC.DAQ.Infrastructure.Entities;

namespace Refact.PLC.DAQ.Infrastructure.Repositories;

public class EmpgRepository
{
    private readonly DongboDaqDbContext _db;

    public EmpgRepository(DongboDaqDbContext db)
    {
        _db = db;
    }

    public virtual async Task InsertAsync(Op100EmpgInsertDto dto, CancellationToken ct = default)
    {
        var entity = ToEntity(dto);
        entity.CreateDaytime = ParseCreateDayTime(dto.CreateDayTime);
        entity.Cycletime = "0";
        _db.Empg.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public virtual async Task InsertAsync(Op200EmpgInsertDto dto, CancellationToken ct = default)
    {
        var entity = ToEntity(dto);
        entity.CreateDaytime = ParseCreateDayTime(dto.CreateDayTime);
        entity.Cycletime = "0";
        _db.Empg.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public virtual async Task InsertAsync(Op210EmpgInsertDto dto, CancellationToken ct = default)
    {
        var entity = ToEntity(dto);
        entity.CreateDaytime = ParseCreateDayTime(dto.CreateDayTime);
        entity.Cycletime = "0";
        _db.Empg.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public virtual async Task InsertAsync(Op220EmpgInsertDto dto, CancellationToken ct = default)
    {
        var entity = ToEntity(dto);
        entity.CreateDaytime = ParseCreateDayTime(dto.CreateDayTime);
        entity.Cycletime = "0";
        _db.Empg.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public virtual async Task InsertAsync(Op230EmpgInsertDto dto, CancellationToken ct = default)
    {
        var entity = ToEntity(dto);
        entity.CreateDaytime = ParseCreateDayTime(dto.CreateDayTime);
        entity.Cycletime = "0";
        _db.Empg.Add(entity);
        await _db.SaveChangesAsync(ct);
    }

    public virtual async Task UpdateAsync(string resultId, Op210EmpgUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await _db.Empg.FirstOrDefaultAsync(x => x.ResultId == resultId, ct);
        if (entity == null) return;
        entity.UpdateTime = dto.UpdateTime;
        entity.TotalJudge = dto.TotalJudge;
        entity.Apd27 = dto.Apd27;
        entity.Apd28 = dto.Apd28;
        entity.Apd29 = dto.Apd29;
        entity.Apd30 = dto.Apd30;
        entity.Sp31 = dto.Sp31;
        entity.Sp32 = dto.Sp32;
        entity.Sp33 = dto.Sp33;
        entity.Sp34 = dto.Sp34;
        entity.Sp35 = dto.Sp35;
        entity.Sp36 = dto.Sp36;
        await _db.SaveChangesAsync(ct);
    }

    public virtual async Task UpdateAsync(string resultId, Op220EmpgUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await _db.Empg.FirstOrDefaultAsync(x => x.ResultId == resultId, ct);
        if (entity == null) return;
        entity.UpdateTime = dto.UpdateTime;
        entity.TotalJudge = dto.TotalJudge;
        entity.Apd31 = dto.Apd31;
        entity.Apd32 = dto.Apd32;
        entity.Apd33 = dto.Apd33;
        await _db.SaveChangesAsync(ct);
    }

    public virtual async Task UpdateAsync(string resultId, Op230EmpgUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await _db.Empg.FirstOrDefaultAsync(x => x.ResultId == resultId, ct);
        if (entity == null) return;
        entity.UpdateTime = dto.UpdateTime;
        entity.TotalJudge = dto.TotalJudge;
        entity.Apd35 = dto.Apd35;
        entity.Apd36 = dto.Apd36;
        entity.Apd37 = dto.Apd37;
        entity.Apd38 = dto.Apd38;
        entity.Apd39 = dto.Apd39;
        entity.Apd40 = dto.Apd40;
        entity.Apd41 = dto.Apd41;
        entity.Apd42 = dto.Apd42;
        entity.Apd43 = dto.Apd43;
        entity.Apd44 = dto.Apd44;
        await _db.SaveChangesAsync(ct);
    }

    public virtual async Task<EmpgRowDto?> FindByMatSerial01Async(string matSerial01, CancellationToken ct = default)
    {
        var entity = await _db.Empg
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.MatSerial01 == matSerial01, ct);
        return entity == null ? null : ToRowDto(entity);
    }

    public virtual async Task<EmpgRowDto?> FindByMatSerial02Async(string matSerial02, CancellationToken ct = default)
    {
        var entity = await _db.Empg
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.MatSerial02 == matSerial02, ct);
        return entity == null ? null : ToRowDto(entity);
    }

    private static EmpgEntity ToEntity(Op100EmpgInsertDto dto)
    {
        return new EmpgEntity
        {
            ResultId = dto.ResultId,
            UpdateTime = dto.UpdateTime,
            Repair = dto.Repair,
            Model = dto.Model,
            MatSerial01 = dto.MatSerial01,
            MatSerial02 = dto.MatSerial02,
            TotalJudge = dto.TotalJudge,
            Apd01 = dto.Apd01,
            Apd02 = dto.Apd02,
            Apd03 = dto.Apd03,
            Apd04 = dto.Apd04,
            Apd05 = dto.Apd05,
            Apd06 = dto.Apd06,
            Apd07 = dto.Apd07,
            Apd08 = dto.Apd08,
            Apd09 = dto.Apd09,
            Apd10 = dto.Apd10,
            Sp01 = dto.Sp01,
            Sp02 = dto.Sp02,
            Sp03 = dto.Sp03,
            Sp04 = dto.Sp04,
            Sp05 = dto.Sp05,
            Sp06 = dto.Sp06,
            Sp07 = dto.Sp07,
            Sp08 = dto.Sp08,
            Sp09 = dto.Sp09,
            Sp10 = dto.Sp10,
            Sp11 = dto.Sp11,
            Sp12 = dto.Sp12,
            Sp13 = dto.Sp13,
            Sp14 = dto.Sp14
        };
    }

    private static EmpgEntity ToEntity(Op200EmpgInsertDto dto)
    {
        return new EmpgEntity
        {
            ResultId = dto.ResultId,
            UpdateTime = dto.UpdateTime,
            Repair = dto.Repair,
            Model = dto.Model,
            MatSerial01 = dto.MatSerial01,
            MatSerial02 = dto.MatSerial02,
            TotalJudge = dto.TotalJudge,
            Apd01 = dto.Apd01,
            Apd02 = dto.Apd02,
            Apd03 = dto.Apd03,
            Apd04 = dto.Apd04,
            Apd05 = dto.Apd05,
            Apd06 = dto.Apd06,
            Apd07 = dto.Apd07,
            Apd08 = dto.Apd08,
            Apd09 = dto.Apd09,
            Apd10 = dto.Apd10,
            Apd11 = dto.Apd11,
            Apd12 = dto.Apd12,
            Apd13 = dto.Apd13,
            Apd14 = dto.Apd14,
            Apd15 = dto.Apd15,
            Apd16 = dto.Apd16,
            Apd17 = dto.Apd17,
            Apd18 = dto.Apd18,
            Apd19 = dto.Apd19,
            Apd20 = dto.Apd20,
            Apd21 = dto.Apd21,
            Apd22 = dto.Apd22,
            Apd23 = dto.Apd23,
            Apd24 = dto.Apd24,
            Apd25 = dto.Apd25,
            Apd26 = dto.Apd26,
            Apd27 = dto.Apd27,
            Apd28 = dto.Apd28,
            Apd29 = dto.Apd29,
            Apd30 = dto.Apd30,
            Apd31 = dto.Apd31,
            Apd32 = dto.Apd32,
            Sp01 = dto.Sp01,
            Sp02 = dto.Sp02,
            Sp03 = dto.Sp03,
            Sp04 = dto.Sp04,
            Sp05 = dto.Sp05,
            Sp06 = dto.Sp06,
            Sp07 = dto.Sp07,
            Sp08 = dto.Sp08,
            Sp09 = dto.Sp09,
            Sp10 = dto.Sp10,
            Sp11 = dto.Sp11,
            Sp12 = dto.Sp12,
            Sp13 = dto.Sp13,
            Sp14 = dto.Sp14,
            Sp15 = dto.Sp15,
            Sp16 = dto.Sp16,
            Sp17 = dto.Sp17,
            Sp18 = dto.Sp18,
            Sp19 = dto.Sp19,
            Sp20 = dto.Sp20,
            Sp21 = dto.Sp21,
            Sp22 = dto.Sp22,
            Sp23 = dto.Sp23,
            Sp24 = dto.Sp24,
            Sp25 = dto.Sp25,
            Sp26 = dto.Sp26,
            Sp27 = dto.Sp27,
            Sp28 = dto.Sp28,
            Sp29 = dto.Sp29,
            Sp30 = dto.Sp30,
            Sp31 = dto.Sp31,
            Sp32 = dto.Sp32,
            Sp33 = dto.Sp33,
            Sp34 = dto.Sp34,
            Sp35 = dto.Sp35,
            Sp36 = dto.Sp36
        };
    }

    private static EmpgEntity ToEntity(Op210EmpgInsertDto dto)
    {
        return new EmpgEntity
        {
            ResultId = dto.ResultId,
            UpdateTime = dto.UpdateTime,
            Repair = dto.Repair,
            Model = dto.Model,
            MatSerial01 = dto.MatSerial01,
            MatSerial02 = dto.MatSerial02,
            TotalJudge = dto.TotalJudge,
            Apd27 = dto.Apd27,
            Apd28 = dto.Apd28,
            Apd29 = dto.Apd29,
            Apd30 = dto.Apd30,
            Sp31 = dto.Sp31,
            Sp32 = dto.Sp32,
            Sp33 = dto.Sp33,
            Sp34 = dto.Sp34,
            Sp35 = dto.Sp35,
            Sp36 = dto.Sp36
        };
    }

    private static EmpgEntity ToEntity(Op220EmpgInsertDto dto)
    {
        return new EmpgEntity
        {
            ResultId = dto.ResultId,
            UpdateTime = dto.UpdateTime,
            Repair = dto.Repair,
            Model = dto.Model,
            MatSerial01 = dto.MatSerial01,
            MatSerial02 = dto.MatSerial02,
            TotalJudge = dto.TotalJudge,
            Apd31 = dto.Apd31,
            Apd32 = dto.Apd32,
            Apd33 = dto.Apd33,
            Sp37 = dto.Sp37,
            Sp38 = dto.Sp38
        };
    }

    private static EmpgEntity ToEntity(Op230EmpgInsertDto dto)
    {
        return new EmpgEntity
        {
            ResultId = dto.ResultId,
            UpdateTime = dto.UpdateTime,
            Repair = dto.Repair,
            Model = dto.Model,
            MatSerial01 = dto.MatSerial01,
            MatSerial02 = dto.MatSerial02,
            TotalJudge = dto.TotalJudge,
            Apd35 = dto.Apd35,
            Apd36 = dto.Apd36,
            Apd37 = dto.Apd37,
            Apd38 = dto.Apd38,
            Apd39 = dto.Apd39,
            Apd40 = dto.Apd40,
            Apd41 = dto.Apd41,
            Apd42 = dto.Apd42,
            Apd43 = dto.Apd43,
            Apd44 = dto.Apd44,
            Sp39 = dto.Sp39,
            Sp40 = dto.Sp40,
            Sp41 = dto.Sp41,
            Sp42 = dto.Sp42,
            Sp43 = dto.Sp43,
            Sp44 = dto.Sp44
        };
    }

    private static EmpgRowDto ToRowDto(EmpgEntity e)
    {
        return new EmpgRowDto(
            e.ResultId,
            e.Model,
            e.MatSerial01,
            e.MatSerial02,
            e.TotalJudge,
            e.UpdateTime,
            e.Apd01,
            e.Apd02,
            e.Apd27,
            e.Apd28,
            e.Apd29,
            e.Apd30
        );
    }

    private static DateTime ParseCreateDayTime(string s)
    {
        return DateTime.TryParse(s, out var dt) ? dt : DateTime.Now;
    }
}
