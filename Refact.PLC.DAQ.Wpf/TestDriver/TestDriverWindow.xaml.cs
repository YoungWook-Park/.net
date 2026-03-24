using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refact.PLC.DAQ.Domain.Handlers;
using Refact.PLC.DAQ.Domain.Plc;
using Refact.PLC.DAQ.Domain.TestDriver;
using Refact.PLC.DAQ.Infrastructure.Data;
using Refact.PLC.DAQ.Infrastructure.Plc;
using Refact.PLC.DAQ.Infrastructure.Repositories;

namespace Refact.PLC.DAQ.Wpf.TestDriver;

public partial class TestDriverWindow : Window
{
    private readonly IServiceScope _scope;

    public TestDriverWindow()
    {
        InitializeComponent();

        var traceSink = new TraceSink();
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();
        services.AddDbContext<DongboDaqDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")!));

        services.AddSingleton<FakePlcDevice>();
        services.AddSingleton<IPlcDevice>(sp => sp.GetRequiredService<FakePlcDevice>());
        services.AddSingleton(traceSink);
        services.AddSingleton<ITraceSink>(sp => sp.GetRequiredService<TraceSink>());

        services.AddScoped<ModelRepository>(sp => new TracingModelRepository(
            sp.GetRequiredService<DongboDaqDbContext>(),
            sp.GetRequiredService<ITraceSink>()));
        services.AddScoped<EmpgRepository>(sp => new TracingEmpgRepository(
            sp.GetRequiredService<DongboDaqDbContext>(),
            sp.GetRequiredService<ITraceSink>()));
        services.AddScoped<IProcessDataHandler, Infrastructure.Handlers.ProcessDataHandler>();
        services.AddScoped<TestDriverWindowViewModel>();

        var serviceProvider = services.BuildServiceProvider();
        _scope = serviceProvider.CreateScope();
        DataContext = _scope.ServiceProvider.GetRequiredService<TestDriverWindowViewModel>();
    }

    protected override void OnClosed(EventArgs e)
    {
        _scope?.Dispose();
        base.OnClosed(e);
    }
}
