using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.models.settings.defaults;
using offshore.data.parsing.loading;
using offshore.data.parsing.models;
using offshore.services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace offshore.installation.setup.ViewModels;

public class MainWindowModel : IMainWindowModel
{
    private readonly IDataModelParser _dataParser;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) => PropertyChanged!(this, new PropertyChangedEventArgs(propertyName));

    public MainWindowModel(IAbstractFactory<ICompleteDataContext> settingsContextFactory,
                            IAbstractFactory<IBusinessDataContext> businessContextFactory,
                            IAbstractFactory<IUserDataContext> usersContextFactory,
                            IAbstractFactory<ILanguageDataContext> languageContextFactory,
                            IDataModelParser dataParser)
    {
        LanguageContextFactory = languageContextFactory;
        _dataParser = dataParser;
        SettingsContextFactory = settingsContextFactory;
        BusinessContextFactory = businessContextFactory;
        UsersContextFactory = usersContextFactory;
        ClearOsOpDataButtonClick = new RelayCommand(new Action<object>(ClearOsOpData));
        DeleteOsOpDataButtonClick = new RelayCommand(new Action<object>(DeleteOsOpData));
        GetOsOpDataButtonClick = new RelayCommand(new Action<object>(GetOsOpData));
        CreateOsOpDatabaseButtonClick = new RelayCommand(new Action<object>(PopulateDefaultData));
        CreateDemoDataButtonClick = new RelayCommand(new Action<object>(PopulateDemoData));
    }

    public IAbstractFactory<ILanguageDataContext> LanguageContextFactory { get; }
    public IAbstractFactory<ICompleteDataContext> SettingsContextFactory { get; }
    public IAbstractFactory<IUserDataContext> UsersContextFactory { get; }
    public IAbstractFactory<IBusinessDataContext> BusinessContextFactory { get; }
    public ICommand CreateOsOpDatabaseButtonClick { get; init; }
    public ICommand ClearOsOpDataButtonClick { get; init; }
    public ICommand DeleteOsOpDataButtonClick { get; init; }
    public ICommand GetOsOpDataButtonClick { get; init; }
    public ICommand CreateDemoDataButtonClick { get; init; }

    public ObservableCollection<Alarm> Alarms { get; } = [];
    public ObservableCollection<Calibration> Calibrations { get; } = [];
    public ObservableCollection<ChangeLog> ChangeLogs { get; } = [];
    public ObservableCollection<Consignment> Consignments { get; } = [];
    public ObservableCollection<LiveDatum> LiveData { get; } = [];
    public ObservableCollection<MeasurementType> Measurements { get; } = [];
    public ObservableCollection<MeasurementUnit> MeasurementUnits { get; } = [];
    public ObservableCollection<Module> Modules { get; } = [];
    public ObservableCollection<ReceivedData> ReceivedData { get; } = [];
    public ObservableCollection<Receiver> ReceiverTypes { get; } = [];
    public ObservableCollection<Sensor> Sensors { get; } = [];
    public ObservableCollection<SinglePointMooring> SinglePointMoorings { get; } = [];
    public ObservableCollection<Site> Sites { get; } = [];
    public ObservableCollection<SiteConfiguration> SiteConfigurations { get; } = [];
    public ObservableCollection<SiteMeasurementUnit> SiteMeasurementDataUnits { get; } = [];
    public ObservableCollection<Telemetry> TelemetryData { get; } = [];

    public ObservableCollection<Language> Languages { get; } = [];
    public ObservableCollection<Translatable> Translatables { get; } = [];
    public ObservableCollection<Translation> Translations { get; } = [];

    public ObservableCollection<Permission> Permissions { get; } = [];
    public ObservableCollection<Role> Roles { get; } = [];
    public ObservableCollection<User> Users { get; } = [];

    private void PopulateDefaultData(object obj)
    {
        if (_dataParser.TryParseDataFile("setup-data\\language-entities.json", out DefaultLanguageDataModel? languageEntities))
            PopulateLanguageDefaults(languageEntities!);
        
        PopulateUserDefaults(); // Keep this one in c#

        if (_dataParser.TryParseDataFile("setup-data\\business-entities.json", out DefaultTelephonyDataModel? businessEntities))
            PopulateTelephonyDefaults(businessEntities!);

        if (_dataParser.TryParseDataFile("setup-data\\configuration-entities.json", out DefaultConfigurationDataModel? configurationEntities))
            PopulateConfigurationDefaults(configurationEntities!);

        //PopulateOffshoreOpsData();
    }

    private void PopulateLanguageDefaults(in DefaultLanguageDataModel entities)
    {
        using var context = LanguageContextFactory.Create();
        LanguageEntityLoader.PopulateDatabase(context, new()
        {
            Languages = entities.Languages!,
            Translatables = entities.Translatables!,
            Translations = entities.Translations!
        });
    }

    private void PopulateUserDefaults()
    {
        using var userContext = UsersContextFactory.Create();
        using var settingsContext = SettingsContextFactory.Create();

        PermissionsAndRolesSetup.PopulateDatabase(userContext, settingsContext);
    }

    private void PopulateTelephonyDefaults(in DefaultTelephonyDataModel entities)
    {
        using var context = BusinessContextFactory.Create();
        TelephonyEntityLoader.PopulateDatabase(context, new()
        {
            TelephoneTypes = entities.TelephoneTypes!,
            Countries = entities.Countries!,
            CountryCodes = entities.CountryCodes!
        });
    }

    private void PopulateConfigurationDefaults(in DefaultConfigurationDataModel entities)
    {
        using var context = SettingsContextFactory.Create();

        ConfigurationEntityLoader.PopulateDatabase(context, new() { 
            MeasurementTypes = entities.MeasurementTypes!,
            MeasurementUnits = entities.MeasurementUnits!,
            Modules = entities.Modules!,
            Receivers = entities.Receivers!,
            Sensors = entities.Sensors!,
            Telemetries = entities.Telemetries!
        });
    }

    private void PopulateOffshoreOpsData()
    {
        using var context = SettingsContextFactory.Create();
        OffshoreOperationsEntityLoader.PopulateDatabase(context);
    }

    private void PopulateDemoData(object obj) => SetupDemoRecords();

    private void SetupDemoRecords()
    {
        using var users = UsersContextFactory.Create();
        using var settings = SettingsContextFactory.Create();
        using var languages = LanguageContextFactory.Create();
        DemoDefaults.PopulateDatabase(settings);
    }

    private void ClearOsOpData(object obj)
    {
        Alarms.Clear();
        Calibrations.Clear();
        ChangeLogs.Clear();
        Consignments.Clear();
        LiveData.Clear();
        Measurements.Clear();
        MeasurementUnits.Clear();
        Modules.Clear();
        ReceivedData.Clear();
        ReceiverTypes.Clear();
        Sensors.Clear();
        SinglePointMoorings.Clear();
        SiteConfigurations.Clear();
        SiteMeasurementDataUnits.Clear();
        Sites.Clear();
        TelemetryData.Clear();

        Languages.Clear();
        Translatables.Clear();
        Translations.Clear();

        Permissions.Clear();
        Roles.Clear();
        Users.Clear();
    }

    private void DeleteOsOpData(object obj)
    {
        ClearOsOpData(obj);
        DeleteSettingsData();
        DeleteBusinessData();
        DeleteLanguageData();
        DeleteUserData();
    }

    private void DeleteBusinessData()
    {
        using var context = SettingsContextFactory.Create();

        context.DeleteAllRecords<Address>()
            .DeleteAllRecords<Country>()
            .DeleteAllRecords<Location>()
            .DeleteAllRecords<Company>()
            .DeleteAllRecords<Contact>()
            .DeleteAllRecords<CountryCode>()
            .DeleteAllRecords<TelephoneNumber>()
            .DeleteAllRecords<TelephoneType>();

        context.SaveChanges();
    }

    private void DeleteLanguageData()
    {
        using var context = LanguageContextFactory.Create();
        context.DeleteAllRecords<Language>()
            .DeleteAllRecords<Translatable>()
            .DeleteAllRecords<Translation>();

        context.SaveChanges();
    }

    private void DeleteSettingsData()
    {
        using var context = SettingsContextFactory.Create();

        context.DeleteAllRecords<Alarm>()
            .DeleteAllRecords<Calibration>()
            .DeleteAllRecords<ChangeLog>()
            .DeleteAllRecords<Consignment>()
            .DeleteAllRecords<LiveDatum>()
            .DeleteAllRecords<MeasurementType>()
            .DeleteAllRecords<MeasurementUnit>()
            .DeleteAllRecords<Module>()
            .DeleteAllRecords<ReceivedData>()
            .DeleteAllRecords<Receiver>()
            .DeleteAllRecords<Sensor>()
            .DeleteAllRecords<SinglePointMooring>()
            .DeleteAllRecords<Site>()
            .DeleteAllRecords<SiteConfiguration>()
            .DeleteAllRecords<SiteMeasurementUnit>()
            .DeleteAllRecords<Telemetry>();

        context.SaveChanges();
    }

    private void DeleteUserData()
    {
        using var context = UsersContextFactory.Create();
        context.DeleteAllRecords<Permission>()
            .DeleteAllRecords<Role>()
            .DeleteAllRecords<User>();

        context.SaveChanges();
    }
    private void GetOsOpData(object obj)
    {
        ClearOsOpData(obj);
        GetLanguageData();
        GetSettingsData();
        GetUserData();
    }

    private void GetUserData()
    {
        using var context = UsersContextFactory.Create();
        Roles.AddRange(context.Roles);
        Users.AddRange(context.Users);
    }

    private void GetLanguageData()
    {
        using var context = LanguageContextFactory.Create();
        Languages.AddRange(context.Languages);
        Translatables.AddRange(context.Translatables);
        Translations.AddRange(context.Translations);
    }

    private void GetSettingsData()
    {
        using var context = SettingsContextFactory.Create();

        Alarms.AddRange(context.Alarms);
        Calibrations.AddRange(context.Calibrations);
        ChangeLogs.AddRange(context.ChangeLogs);
        Consignments.AddRange(context.Consignments);
        LiveData.AddRange(context.LiveData);
        Measurements.AddRange(context.MeasurementTypes);
        MeasurementUnits.AddRange(context.MeasurementUnits);
        Modules.AddRange(context.Modules);
        ReceivedData.AddRange(context.ReceivedData);
        ReceiverTypes.AddRange(context.Receivers);
        Sensors.AddRange(context.Sensors);
        SinglePointMoorings.AddRange(context.SinglePointMoorings);
        SiteConfigurations.AddRange(context.SiteConfigurations);
        SiteMeasurementDataUnits.AddRange(context.SiteMeasurementUnits);
        Sites.AddRange(context.Sites);
        TelemetryData.AddRange(context.TelemetryData);
    }
}
