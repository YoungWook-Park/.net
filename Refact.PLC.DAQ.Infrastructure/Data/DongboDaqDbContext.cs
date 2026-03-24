using Microsoft.EntityFrameworkCore;
using Refact.PLC.DAQ.Infrastructure.Entities;

namespace Refact.PLC.DAQ.Infrastructure.Data;

public class DongboDaqDbContext : DbContext
{
    public DongboDaqDbContext(DbContextOptions<DongboDaqDbContext> options)
        : base(options)
    {
    }

    public DbSet<EmpgEntity> Empg => Set<EmpgEntity>();
    public DbSet<StsModelEntity> StsModel => Set<StsModelEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StsModelEntity>(e =>
        {
            e.ToTable("STS_MODEL_TB");
            e.HasKey(x => x.Model);
            e.Property(x => x.Model).HasColumnName("MODEL");
            e.Property(x => x.ModelDesc).HasColumnName("MODEL_DESC");
            e.Property(x => x.ProductionQty).HasColumnName("PRODUCTION_QTY");
            e.Property(x => x.FinishedQty).HasColumnName("FINISHED_QTY");
            e.Property(x => x.DefectiveQty).HasColumnName("DEFECTIVE_QTY");
            e.Property(x => x.Yield).HasColumnName("YIELD");
            e.Property(x => x.CreatedTime).HasColumnName("CREATED_TIME");
            e.Property(x => x.UpdatedTime).HasColumnName("UPDATED_TIME");
        });

        modelBuilder.Entity<EmpgEntity>(e =>
        {
            e.ToTable("EMPG");
            e.HasKey(x => x.ResultId);
            e.Property(x => x.ResultId).HasColumnName("RESULT_ID");
            e.Property(x => x.UpdateTime).HasColumnName("UPDATE_TIME");
            e.Property(x => x.Repair).HasColumnName("REPAIR");
            e.Property(x => x.Model).HasColumnName("MODEL");
            e.Property(x => x.Ifdate).HasColumnName("IFDATE");
            e.Property(x => x.Ifflag).HasColumnName("IFFLAG");
            e.Property(x => x.SpcFlag).HasColumnName("SPC_FLAG");
            e.Property(x => x.MasterFlag).HasColumnName("MASTER_FLAG");
            e.Property(x => x.Cycletime).HasColumnName("CYCLETIME");
            e.Property(x => x.CreateDaytime).HasColumnName("CREATE_DAYTIME");
            e.Property(x => x.MatSerial01).HasColumnName("MAT_SERIAL01");
            e.Property(x => x.MatSerial02).HasColumnName("MAT_SERIAL02");
            e.Property(x => x.TotalJudge).HasColumnName("TOTAL_JUDGE");

            e.Property(x => x.Op100TotalJudge).HasColumnName("OP100_TOTAL_JUDGE");
            e.Property(x => x.Op200TotalJudge).HasColumnName("OP200_TOTAL_JUDGE");
            e.Property(x => x.Op300TotalJudge).HasColumnName("OP300_TOTAL_JUDGE");

            for (var i = 1; i <= 60; i++)
                e.Property($"Apd{i:D2}").HasColumnName($"APD{i:D2}");
            for (var i = 1; i <= 70; i++)
                e.Property($"Sp{i:D2}").HasColumnName($"SP{i:D2}");
        });
    }
}
