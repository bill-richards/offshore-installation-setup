using Microsoft.EntityFrameworkCore;
using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.models.settings.defaults;
using offshore.services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace offshore.installation.setup.ViewModels;

public class MainWindowModel : IMainWindowModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) => PropertyChanged!(this, new PropertyChangedEventArgs(propertyName));

    public MainWindowModel(IAbstractFactory<ISettingsDataContext> settingsContextFactory,
                            IAbstractFactory<IBusinessDataContext> businessContextFactory,
                            IAbstractFactory<IUserDataContext> usersContextFactory,
                            IAbstractFactory<ILanguageDataContext> languageContextFactory)
    {
        LanguageContextFactory = languageContextFactory;
        SettingsContextFactory = settingsContextFactory;
        BusinessContextFactory = businessContextFactory;
        UsersContextFactory = usersContextFactory;
        ClearOsOpDataButtonClick = new RelayCommand(new Action<object>(ClearOsOpData));
        DeleteOsOpDataButtonClick = new RelayCommand(new Action<object>(DeleteOsOpData));
        GetOsOpDataButtonClick = new RelayCommand(new Action<object>(GetOsOpData));
        CreateOsOpDatabaseButtonClick = new RelayCommand(new Action<object>(PopulateOsOpDatabase));
        CreateDemoDataButtonClick = new RelayCommand(new Action<object>(PopulateDemoData));
    }

    public IAbstractFactory<ILanguageDataContext> LanguageContextFactory { get; }
    public IAbstractFactory<ISettingsDataContext> SettingsContextFactory { get; }
    public IAbstractFactory<IUserDataContext> UsersContextFactory { get; }
    public IAbstractFactory<IBusinessDataContext> BusinessContextFactory { get; }
    public ICommand CreateOsOpDatabaseButtonClick { get; init; }
    public ICommand ClearOsOpDataButtonClick { get; init; }
    public ICommand DeleteOsOpDataButtonClick { get; init; }
    public ICommand GetOsOpDataButtonClick { get; init; }
    public ICommand CreateDemoDataButtonClick { get; init; }

    public ObservableCollection<Alarm> Alarms { get; } = new ObservableCollection<Alarm>();
    public ObservableCollection<Calibration> Calibrations { get; } = new ObservableCollection<Calibration>();
    public ObservableCollection<ChangeLog> ChangeLogs { get; } = new ObservableCollection<ChangeLog>();
    public ObservableCollection<Consignment> Consignments { get; } = new ObservableCollection<Consignment>();
    public ObservableCollection<LiveDatum> LiveData { get; } = new ObservableCollection<LiveDatum>();
    public ObservableCollection<MeasurementType> Measurements { get; } = new ObservableCollection<MeasurementType>();
    public ObservableCollection<MeasurementUnit> MeasurementUnits { get; } = new ObservableCollection<MeasurementUnit>();
    public ObservableCollection<Module> Modules { get; } = new ObservableCollection<Module>();
    public ObservableCollection<ReceivedData> ReceivedData { get; } = new ObservableCollection<ReceivedData>();
    public ObservableCollection<Receiver> ReceiverTypes { get; } = new ObservableCollection<Receiver>();
    public ObservableCollection<Sensor> Sensors { get; } = new ObservableCollection<Sensor>();
    public ObservableCollection<SinglePointMooring> SinglePointMoorings { get; } = new ObservableCollection<SinglePointMooring>();
    public ObservableCollection<Site> Sites { get; } = new ObservableCollection<Site>();
    public ObservableCollection<SiteConfiguration> SiteConfigurations { get; } = new ObservableCollection<SiteConfiguration>();
    public ObservableCollection<SiteMeasurementUnit> SiteMeasurementDataUnits { get; } = new ObservableCollection<SiteMeasurementUnit>();
    public ObservableCollection<Telemetry> TelemetryData { get; } = new ObservableCollection<Telemetry>();

    public ObservableCollection<Language> Languages { get; } = new ObservableCollection<Language>();
    public ObservableCollection<Translatable> Translatables { get; } = new ObservableCollection<Translatable>();
    public ObservableCollection<Translation> Translations { get; } = new ObservableCollection<Translation>();

    public ObservableCollection<Permission> Permissions { get; } = new ObservableCollection<Permission>();
    public ObservableCollection<Role> Roles { get; } = new ObservableCollection<Role>();
    public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();

    private void PopulateOsOpDatabase(object obj)
    {
        PopulateBusinessDefaults();
        PopulateLanguageData();
        PopulateUserData();
        PopulateSettingsData();

        PopulateOffshoreOpsData();
    }

    private void PopulateDemoData(object obj) => SetupDemoRecords();

    private void SetupDemoRecords()
    {
        using var users = UsersContextFactory.Create();
        using var settings = SettingsContextFactory.Create();
        using var languages = LanguageContextFactory.Create();
        DemoDefaults.PopulateDatabase(settings);
    }

    private void PopulateOffshoreOpsData()
    {
        using var context = SettingsContextFactory.Create();
        OffshoreOperationsDataSetup.PopulateDatabase(context);
    }

    private void PopulateBusinessDefaults()
    {
        using var context = BusinessContextFactory.Create();
        BusinessDefaults.PopulateDatabase(context);
    }

    private void PopulateLanguageData()
    {
        using var context = LanguageContextFactory.Create();

        TranslationDefaults.PopulateDatabase(context);
    }
    private void PopulateSettingsData()
    {
        using var context = SettingsContextFactory.Create();

        MeasurementDefaults.PopulateDatabase(context);
        TelemetryDefaults.PopulateDatabase(context);
        ModuleDefaults.PopulateDatabase(context);
    }
    private void PopulateUserData()
    {
        using var userContext = UsersContextFactory.Create();
        using var settingsContext = SettingsContextFactory.Create();

        UserDefaults.PopulateDatabase(userContext, settingsContext);
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
            .DeleteAllRecords<SpmModule>()
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
