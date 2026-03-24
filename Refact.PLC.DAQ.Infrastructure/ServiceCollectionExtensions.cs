using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refact.PLC.DAQ.Domain.Handlers;
using Refact.PLC.DAQ.Domain.Plc;
using Refact.PLC.DAQ.Infrastructure.Data;
using Refact.PLC.DAQ.Infrastructure.Handlers;
using Refact.PLC.DAQ.Infrastructure.Orchestration;
using Refact.PLC.DAQ.Infrastructure.Plc;
using Refact.PLC.DAQ.Infrastructure.Repositories;

namespace Refact.PLC.DAQ.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDongboDaqInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default")
            ?? throw new InvalidOperationException("Connection string 'Default' not found.");

        services.AddDbContext<DongboDaqDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<EmpgRepository>();
        services.AddScoped<ModelRepository>();
        services.AddScoped<IProcessDataHandler, ProcessDataHandler>();
        services.AddScoped<IPlcDevice, FakePlcDevice>();
        services.AddScoped<DaqOrchestrator>();

        return services;
    }
}
