using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refact.PLC.DAQ.Domain.Options;
using Refact.PLC.DAQ.Infrastructure;
using Refact.PLC.DAQ.Wpf.Services;

namespace Refact.PLC.DAQ.Wpf;

public partial class App : Application
{
    private IServiceProvider? _serviceProvider;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.AddConfiguration(configuration.GetSection("Logging"));
            builder.AddDebug();
        });

        services.AddOptions<AppOptions>()
            .Bind(configuration.GetSection(AppOptions.SectionName));

        services.AddDongboDaqInfrastructure(configuration);

        services.AddSingleton<IOpenWindowService, OpenWindowService>();
        services.AddTransient<MainWindowViewModel>();

        _serviceProvider = services.BuildServiceProvider();

        var mainWindow = new MainWindow
        {
            DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>()
        };
        mainWindow.Show();
    }
}
