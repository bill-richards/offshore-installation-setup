using example.data.models.contexts;
using offshore.installation.setup.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using offshore.data;
using offshore.data.sqlite;
using offshore.data.sqlite.contexts;
using offshore.services;
using System;
using System.Windows;

namespace offshore.installation.setup;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddSingleton<DataConfigurationFile>();

                services.AddTransient<IMainWindowModel, MainWindowModel>();
                services.AddTransient<IOffshoreDbConfiguration, OffshoreSqliteDbConfiguration>();
                
                services.AddFactory<ILibraryContext, LibraryContext>(factory: provider =>
                {
                    var dataConfiguration = (provider.GetService(typeof(DataConfigurationFile)) as DataConfigurationFile)!.Configuration;
                    var databaseConfiguration = provider.GetService(typeof(IOffshoreDbConfiguration)) as IOffshoreDbConfiguration;
                    var path = $"{dataConfiguration.DataFolder}/Books_{DateTime.Now.Year}{DateTime.Now.Month}.sqlite";
                    return new LibraryContext(databaseConfiguration!, path);
                });
                services.AddFactory<ISettingsDataContext, SettingsDataContext>(factory: provider =>
                {
                    var dataConfiguration = (provider.GetService(typeof(DataConfigurationFile)) as DataConfigurationFile)!.Configuration;
                    var databaseConfiguration = provider.GetService(typeof(IOffshoreDbConfiguration)) as IOffshoreDbConfiguration;
                    var path = $"{dataConfiguration.DataFolder}/{dataConfiguration.Licence}OPSTELSET.sqlite";
                    return new SettingsDataContext(databaseConfiguration!, path);
                });

            }).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();
        var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
        startupForm.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
