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
using System.Linq;
using offshore.data.sqlexpress;

namespace offshore.installation.setup;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        var configurationFile = new DataConfigurationFile();
        var siteConfiguration = configurationFile!.SiteConfiguration;
        var store = siteConfiguration.Store;

        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddTransient<IMainWindowModel, MainWindowModel>();

                if(store!.Equals("express"))
                    ConfigureSqlExpressStore(services, configurationFile.ExpressConfiguration);
                else
                    ConfigureSqliteStore(services, configurationFile.LiteConfiguration, siteConfiguration!.Licence);

            }).Build();
    }

    private static void ConfigureSqlExpressStore(IServiceCollection services, DataConfigurationFile configuration)
    {
        services.AddTransient<IOffshoreDbConfiguration, OffshoreSqlExpressDbConfiguration>();
        services.AddFactory<ISettingsDataContext, SettingsDataContext>(factory: provider =>
        {
            var connectionString = $"server={configuration.Server};database={configuration.Database};trusted_connection=true;TrustServerCertificate=True";

            var databaseConfiguration = provider.GetService<IOffshoreDbConfiguration>(); //.First(s => s.DatabaseType == "SqlExpress");
            return new SettingsDataContext(databaseConfiguration!, connectionString);
        });
    }

    private static void ConfigureSqliteStore(IServiceCollection services, DataConfigurationFile configuration, uint? licence)
    {
        services.AddTransient<IOffshoreDbConfiguration, OffshoreSqliteDbConfiguration>();
        services.AddFactory<ISettingsDataContext, SettingsDataContext>(factory: provider =>
        {
            var path = $"{configuration.DataFolder}/{licence}OPSTELSET.sqlite";

            var databaseConfiguration = provider.GetService<IOffshoreDbConfiguration>(); //.First(s => s.DatabaseType == "Sqlite");
            return new SettingsDataContext(databaseConfiguration!, path, "Sqlite");
        });
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
