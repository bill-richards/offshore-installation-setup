using Microsoft.EntityFrameworkCore;
using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.models.settings.defaults;
using offshore.services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace offshore.installation.setup.ViewModels;

public class MainWindowModel : IMainWindowModel
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) => PropertyChanged!(this, new PropertyChangedEventArgs(propertyName));

    public MainWindowModel(IAbstractFactory<ISettingsDataContext> offshoreFactory)
    {
        OffshoreContextFactory = offshoreFactory;
        ClearOsOpDataButtonClick = new RelayCommand(new Action<object>(ClearOsOpData));
        DeleteOsOpDataButtonClick = new RelayCommand(new Action<object>(DeleteOsOpData));
        GetOsOpDataButtonClick = new RelayCommand(new Action<object>(GetOsOpData));
        CreateOsOpDatabaseButtonClick = new RelayCommand(new Action<object>(PopulateOsOpDatabase));
    }

    public IAbstractFactory<ISettingsDataContext> OffshoreContextFactory { get; }
    public ICommand CreateOsOpDatabaseButtonClick { get; set; }
    public ICommand ClearOsOpDataButtonClick { get; set; }
    public ICommand DeleteOsOpDataButtonClick { get; set; }
    public ICommand GetOsOpDataButtonClick { get; set; }

    public ObservableCollection<Alarm> Alarms { get; } = new ObservableCollection<Alarm>();
    public ObservableCollection<Calibration> Calibrations { get; } = new ObservableCollection<Calibration>();
    public ObservableCollection<ChangeLog> ChangeLogs { get; } = new ObservableCollection<ChangeLog>();
    public ObservableCollection<Consignment> Consignments { get; } = new ObservableCollection<Consignment>();
    public ObservableCollection<LiveDatum> LiveData { get; } = new ObservableCollection<LiveDatum>();
    public ObservableCollection<Measurement> Measurements { get; } = new ObservableCollection<Measurement>();
    public ObservableCollection<MeasurementDataUnit> MeasurementDataUnits { get; } = new ObservableCollection<MeasurementDataUnit>();
    public ObservableCollection<MeasurementUnit> MeasurementUnits { get; } = new ObservableCollection<MeasurementUnit>();
    public ObservableCollection<Module> Modules { get; } = new ObservableCollection<Module>();
    public ObservableCollection<ReceivedData> ReceivedData { get; } = new ObservableCollection<ReceivedData>();
    public ObservableCollection<Sensor> Sensors { get; } = new ObservableCollection<Sensor>();
    public ObservableCollection<SinglePointMooring> SinglePointMoorings { get; } = new ObservableCollection<SinglePointMooring>();
    public ObservableCollection<SinglePointMooringModule> SinglePointMooringModules { get; } = new ObservableCollection<SinglePointMooringModule>();
    public ObservableCollection<Site> Sites { get; } = new ObservableCollection<Site>();
    public ObservableCollection<SiteConfiguration> SiteConfigurations { get; } = new ObservableCollection<SiteConfiguration>();
    public ObservableCollection<SiteMeasurementDataUnit> SiteMeasurementDataUnits { get; } = new ObservableCollection<SiteMeasurementDataUnit>();
    public ObservableCollection<SupportedLanguage> Languages { get; } = new ObservableCollection<SupportedLanguage>();
    public ObservableCollection<Telemetry> TelemetryData { get; } = new ObservableCollection<Telemetry>();
    public ObservableCollection<Translatable> Translatables { get; } = new ObservableCollection<Translatable>();
    public ObservableCollection<Translation> Translations { get; } = new ObservableCollection<Translation>();

    private void PopulateOsOpDatabase(object obj)
    {
        var osOpContext = OffshoreContextFactory.Create();

        TranslationDefaults.PopulateDatabase(osOpContext);
        MeasurementDefaults.PopulateDatabase(osOpContext);
        ModuleDefaults.PopulateDatabase(osOpContext);
    }

    private void ClearOsOpData(object obj)
    {
        Alarms.Clear();
        Calibrations.Clear();
        ChangeLogs.Clear();
        Consignments.Clear();
        LiveData.Clear();
        Measurements.Clear();
        MeasurementDataUnits.Clear();
        MeasurementUnits.Clear();
        Modules.Clear();
        ReceivedData.Clear();
        Sensors.Clear();
        SinglePointMoorings.Clear();
        SinglePointMooringModules.Clear();
        Sites.Clear();
        SiteConfigurations.Clear();
        SiteMeasurementDataUnits.Clear();
        Languages.Clear();
        TelemetryData.Clear();
        Translatables.Clear();
        Translations.Clear();
    }

    private void DeleteOsOpData(object obj)
    {
        ClearOsOpData(obj);
        using var context = OffshoreContextFactory.Create();

        context.DeleteAllRecords<Alarm>()
            .DeleteAllRecords<Calibration>()
            .DeleteAllRecords<Calibration>()
            .DeleteAllRecords<ChangeLog>()
            .DeleteAllRecords<Consignment>()
            .DeleteAllRecords<LiveDatum>()
            .DeleteAllRecords<Measurement>()
            .DeleteAllRecords<MeasurementDataUnit>()
            .DeleteAllRecords<MeasurementUnit>()
            .DeleteAllRecords<Module>()
            .DeleteAllRecords<ReceivedData>()
            .DeleteAllRecords<Sensor>()
            .DeleteAllRecords<SinglePointMooring>()
            .DeleteAllRecords<SinglePointMooringModule>()
            .DeleteAllRecords<Site>()
            .DeleteAllRecords<SiteConfiguration>()
            .DeleteAllRecords<SiteMeasurementDataUnit>()
            .DeleteAllRecords<SupportedLanguage>()
            .DeleteAllRecords<Telemetry>()
            .DeleteAllRecords<Translatable>()
            .DeleteAllRecords<Translation>();

        context.SaveChanges();
    }

    private void GetOsOpData(object obj)
    {
        ClearOsOpData(obj);
        using var context = OffshoreContextFactory.Create();

        Alarms.AddRange(context.Alarms);
        Calibrations.AddRange(context.Calibrations);
        ChangeLogs.AddRange(context.ChangeLogs);
        Consignments.AddRange(context.Consignments);
        LiveData.AddRange(context.LiveData);
        Measurements.AddRange(context.Measurements);
        MeasurementDataUnits.AddRange(context.MeasurementDataUnits);
        MeasurementUnits.AddRange(context.MeasurementUnits);
        Modules.AddRange(context.Modules);
        ReceivedData.AddRange(context.ReceivedData);
        Sensors.AddRange(context.Sensors);
        SinglePointMoorings.AddRange(context.SinglePointMoorings);
        SinglePointMooringModules.AddRange(context.SinglePointMooringModules);
        Sites.AddRange(context.Sites);
        SiteConfigurations.AddRange(context.SiteConfigurations);
        SiteMeasurementDataUnits.AddRange(context.SiteMeasurementDataUnits);
        Languages.AddRange(context.Languages);
        TelemetryData.AddRange(context.TelemetryData);
        Translatables.AddRange(context.Translatables);
        Translations.AddRange(context.Translations);
    }
}
