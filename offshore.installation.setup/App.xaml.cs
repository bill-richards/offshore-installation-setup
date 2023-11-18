using offshore.installation.setup.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using offshore.data;
using offshore.data.sqlite;
using offshore.services;
using System.Windows;
using offshore.data.sqlexpress;
using MongoDB.Driver;
using offshore.data.mongodb;
using offshore.data.models.settings.contexts;
using Microsoft.EntityFrameworkCore;
using offshore.data.parsing;

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
                services.AddTransient<IDataConfigurationFile, DataConfigurationFile>();
                services.AddSingleton<IDataModelParser, DataModelParser>();

                if (store!.Equals(configurationFile.SqlExpressSectionName))
                    ConfigureSqlExpressStore(services);
                else if (store!.Equals(configurationFile.MongoSectionName))
                    ConfigureMongoDbStore(services);
                else if (store!.Equals(configurationFile.SqliteSectionName))
                    ConfigureSqliteStore(services, siteConfiguration!.Licence);

            }).Build();

        using var scope = AppHost.Services.CreateScope();
        using var settings = scope.ServiceProvider.GetRequiredService<IConfigurationDataContext>();

        settings.Database.Migrate();
    }

    private static void ConfigureMongoDbStore(IServiceCollection services)
    {
        services.AddSingleton<IMongoClient, MongoClient>(implementationFactory: provider => 
        {
            var configFile = provider.GetService<IDataConfigurationFile>();
            var configuration = configFile!.MongoConfiguration;

            var connectionString = $"mongodb://{configuration.Server}:{configuration.Port}";
            return new MongoClient(connectionString);
        });

        services.AddSingleton<IOffshoreDbConfiguration, OffshoreMongoDbConfiguration>(implementationFactory: provider =>
        {
            var configFile = provider.GetService<IDataConfigurationFile>();
            var configuration = configFile!.MongoConfiguration;

            var client = provider.GetService<IMongoClient>();
            return new OffshoreMongoDbConfiguration(client!.GetDatabase(configuration.Database));
        });

        services.AddFactory<IConfigurationDataContext, CompleteDataContext>(factory: provider =>
        {
            var databaseConfiguration = provider.GetService<IOffshoreDbConfiguration>(); //.First(s => s.DatabaseType == "MongoDb");
            return new CompleteDataContext((databaseConfiguration as ISettingsSchema)!, provider.GetService<IDataConfigurationFile>()!);
        });
    }

    private static void ConfigureSqlExpressStore(IServiceCollection services)
    {
        services.AddSingleton<ISettingsSchema, OffshoreSqlExpressDbConfiguration>(implementationFactory: provider =>
        {
            var configFile = provider.GetService<IDataConfigurationFile>();
            var configuration = configFile!.ExpressConfiguration;
            var schemata = configFile!.SchemataConfiguration;

            var connectionString = $"server={configuration.Server};database={configuration.Database};trusted_connection=true;TrustServerCertificate=True";
            return new OffshoreSqlExpressDbConfiguration(connectionString, schemata.SettingsSchema!);
        });
        services.AddFactory<IConfigurationDataContext, CompleteDataContext>();
        //services.AddFactory<ISettingsDataContext, SettingsDataContext>(factory: provider =>
        //{
        //    var databaseConfiguration = provider.GetService<IOffshoreDbConfiguration>(); //.First(s => s.DatabaseType == "SqlExpress");
        //    return new SettingsDataContext(databaseConfiguration!);
        //});

        services.AddSingleton<IConfigurationSchema, OffshoreSqlExpressDbConfiguration>(implementationFactory: provider =>
        {
            var configFile = provider.GetService<IDataConfigurationFile>();
            var configuration = configFile!.ExpressConfiguration;
            var schemata = configFile!.SchemataConfiguration;

            var connectionString = $"server={configuration.Server};database={configuration.Database};trusted_connection=true;TrustServerCertificate=True";
            return new OffshoreSqlExpressDbConfiguration(connectionString, schemata.ConfigurationSchema!);
        });
        services.AddFactory<ICompleteDataContext, CompleteDataContext>();

        services.AddSingleton<IUsersSchema, OffshoreSqlExpressDbConfiguration>(implementationFactory: provider =>
        {
            var configFile = provider.GetService<IDataConfigurationFile>();
            var configuration = configFile!.ExpressConfiguration;
            var schemata = configFile!.SchemataConfiguration;

            var connectionString = $"server={configuration.Server};database={configuration.Database};trusted_connection=true;TrustServerCertificate=True";
            return new OffshoreSqlExpressDbConfiguration(connectionString, schemata.UsersSchema!);
        });
        services.AddFactory<IUserDataContext, UserDataContext>();

        services.AddSingleton<ILanguageSchema, OffshoreSqlExpressDbConfiguration>(implementationFactory: provider =>
        {
            var configFile = provider.GetService<IDataConfigurationFile>();
            var configuration = configFile!.ExpressConfiguration;
            var schemata = configFile!.SchemataConfiguration;

            var connectionString = $"server={configuration.Server};database={configuration.Database};trusted_connection=true;TrustServerCertificate=True";
            return new OffshoreSqlExpressDbConfiguration(connectionString, schemata.LanguageSchema!);
        });
        services.AddFactory<ILanguageDataContext, LanguageDataContext>();

        services.AddSingleton<IBusinessSchema, OffshoreSqlExpressDbConfiguration>(implementationFactory: provider =>
        {
            var configFile = provider.GetService<IDataConfigurationFile>();
            var configuration = configFile!.ExpressConfiguration;
            var schemata = configFile!.SchemataConfiguration;

            var connectionString = $"server={configuration.Server};database={configuration.Database};trusted_connection=true;TrustServerCertificate=True";
            return new OffshoreSqlExpressDbConfiguration(connectionString, schemata.BusinessSchema!);
        });
        services.AddFactory<IBusinessDataContext, BusinessDataContext>();
    }

    private static void ConfigureSqliteStore(IServiceCollection services, uint? licence)
    {
        services.AddSingleton<IOffshoreDbConfiguration, OffshoreSqliteDbConfiguration>(implementationFactory: provider =>
        {
            var configFile = provider.GetService<IDataConfigurationFile>();
            var configuration = configFile!.LiteConfiguration;

            var path = $"{configuration.DataFolder}/{licence}OPSTELSET.sqlite";
            return new OffshoreSqliteDbConfiguration(path);
        });

        services.AddFactory<IConfigurationDataContext, CompleteDataContext>(factory: provider =>
        {
            var databaseConfiguration = provider.GetService<IOffshoreDbConfiguration>(); //.First(s => s.DatabaseType == "Sqlite");
            return new CompleteDataContext((databaseConfiguration as ISettingsSchema)!, provider.GetService<IDataConfigurationFile>()!, "Sqlite");
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
