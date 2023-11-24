using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.models.settings.defaults;
using offshore.data.parsing.Json;
using offshore.data.parsing.loading;
using offshore.data.parsing.models;
using offshore.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace offshore.installation.setup.ViewModels;

public class MainWindowModel : IMainWindowModel
{
    private readonly IDataModelParser DataParser;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) => PropertyChanged!(this, new PropertyChangedEventArgs(propertyName));

    public MainWindowModel(IAbstractFactory<ICompleteDataContext> settingsContextFactory,
                            IAbstractFactory<IBusinessDataContext> businessContextFactory,
                            IAbstractFactory<IUserDataContext> usersContextFactory,
                            IAbstractFactory<ILanguageDataContext> languageContextFactory,
                            IDataModelParser dataParser,
                            IJsonSchemaValidator schemaValidator)
    {
        LanguageContextFactory = languageContextFactory;
        DataParser = dataParser;
        JsonSchemaValidator = schemaValidator;
        SettingsContextFactory = settingsContextFactory;
        BusinessContextFactory = businessContextFactory;
        UsersContextFactory = usersContextFactory;
        ClearOsOpDataButtonClick = new RelayCommand(new Action<object>(ClearOsOpData));
        DeleteOsOpDataButtonClick = new RelayCommand(new Action<object>(DeleteOsOpData));
        GetOsOpDataButtonClick = new RelayCommand(new Action<object>(GetOsOpData));
        CreateOsOpDatabaseButtonClick = new RelayCommand(new Action<object>(PopulateDefaultData));
        CreateDemoDataButtonClick = new RelayCommand(new Action<object>(PopulateDemoData));
        ValidateOsOpDataButtonClick = new RelayCommand(new Action<object>(ValidateDataFile));
    }

    private void ValidateDataFile(object obj)
    {
        JsonSchemaValidator.ValidateDataAgainstSchema($"{AppDomain.CurrentDomain.BaseDirectory}\\setup-data\\offshore-ops.json",
                                                        "offshore-operations-company-structure-schema.json", out var validationErrors);
        foreach(var error in validationErrors)
            Debug.WriteLine(error);
    }

    public IAbstractFactory<ILanguageDataContext> LanguageContextFactory { get; }
    public IJsonSchemaValidator JsonSchemaValidator { get; }
    public IAbstractFactory<ICompleteDataContext> SettingsContextFactory { get; }
    public IAbstractFactory<IUserDataContext> UsersContextFactory { get; }
    public IAbstractFactory<IBusinessDataContext> BusinessContextFactory { get; }
    public ICommand CreateOsOpDatabaseButtonClick { get; init; }
    public ICommand ClearOsOpDataButtonClick { get; init; }
    public ICommand DeleteOsOpDataButtonClick { get; init; }
    public ICommand GetOsOpDataButtonClick { get; init; }
    public ICommand CreateDemoDataButtonClick { get; init; }
    public ICommand ValidateOsOpDataButtonClick { get; init; }

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

    public ObservableCollection<data.models.settings.Language> Languages { get; } = [];
    public ObservableCollection<Translatable> Translatables { get; } = [];
    public ObservableCollection<Translation> Translations { get; } = [];

    public ObservableCollection<Permission> Permissions { get; } = [];
    public ObservableCollection<Role> Roles { get; } = [];
    public ObservableCollection<data.models.settings.User> Users { get; } = [];

    private void PopulateDefaultData(object obj)
    {
        if (DataParser.TryParseDataFile("setup-data\\language.json", out DefaultLanguageDataModel? languageEntities))
            PopulateLanguageDefaults(languageEntities!);

        PopulateUserDefaults(); // Keep this one in c#

        if (DataParser.TryParseDataFile("setup-data\\business.json", out DefaultTelephonyDataModel? businessEntities))
            PopulateTelephonyDefaults(businessEntities!);

        if (DataParser.TryParseDataFile("setup-data\\configuration.json", out DefaultConfigurationDataModel? configurationEntities))
            PopulateConfigurationDefaults(configurationEntities!);

        if (DataParser.TryParseDataFile("setup-data\\offshore-ops.json", out CompanyDataModel? companyEntities))
            PopulateOffshoreOpsDefaults(companyEntities!);
    }

    private void PopulateLanguageDefaults(in DefaultLanguageDataModel entities)
    {
        using var context = LanguageContextFactory.Create();
        LanguageEntityLoader.PopulateDatabase(context, entities);
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
        TelephonyEntityLoader.PopulateDatabase(context, entities);
    }

    private void PopulateConfigurationDefaults(in DefaultConfigurationDataModel entities)
    {
        using var context = SettingsContextFactory.Create();
        ConfigurationEntityLoader.PopulateDatabase(context, entities);
    }

    private void PopulateOffshoreOpsDefaults(in CompanyDataModel companyEntities)
    {
        using var context = SettingsContextFactory.Create();
        CompanyDetailsEntityLoader.PopulateDatabase(context, companyEntities);
    }

    private void PopulateDemoData(object obj) => SetupDemoRecords();

    private void SetupDemoRecords()
    {
        using var settings = SettingsContextFactory.Create();
        DemoDataImporter.PopulateDatabase(settings);
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

        context.DeleteAllRecords<data.models.settings.Address>()
            .DeleteAllRecords<data.models.settings.Country>()
            .DeleteAllRecords<data.models.settings.Location>()
            .DeleteAllRecords<data.models.settings.Company>()
            .DeleteAllRecords<data.models.settings.Contact>()
            .DeleteAllRecords<data.models.settings.CountryCode>()
            .DeleteAllRecords<data.models.settings.TelephoneNumber>()
            .DeleteAllRecords<data.models.settings.TelephoneType>();

        context.SaveChanges();
    }

    private void DeleteLanguageData()
    {
        using var context = LanguageContextFactory.Create();
        context.DeleteAllRecords<data.models.settings.Language>()
            .DeleteAllRecords<data.models.settings.Translatable>()
            .DeleteAllRecords<data.models.settings.Translation>();

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
            .DeleteAllRecords<data.models.settings.User>();

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
