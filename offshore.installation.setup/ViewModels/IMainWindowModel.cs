using offshore.data.models.settings;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace offshore.installation.setup.ViewModels;

public interface IMainWindowModel : INotifyPropertyChanged
{
    ObservableCollection<Alarm> Alarms { get; }
    ObservableCollection<Calibration> Calibrations { get; }
    ObservableCollection<ChangeLog> ChangeLogs { get; }
    ObservableCollection<Consignment> Consignments { get; }
    ObservableCollection<LiveDatum> LiveData { get; } 
    ObservableCollection<Measurement> Measurements { get; } 
    ObservableCollection<MeasurementDataUnit> MeasurementDataUnits { get; }
    ObservableCollection<MeasurementUnit> MeasurementUnits { get; } 
    ObservableCollection<Module> Modules { get; } 
    ObservableCollection<ReceivedData> ReceivedData { get; } 
    ObservableCollection<Sensor> Sensors { get; } 
    ObservableCollection<SinglePointMooring> SinglePointMoorings { get; }
    ObservableCollection<SinglePointMooringModule> SinglePointMooringModules { get; } 
    ObservableCollection<Site> Sites { get; } 
    ObservableCollection<SiteConfiguration> SiteConfigurations { get; } 
    ObservableCollection<SiteMeasurementDataUnit> SiteMeasurementDataUnits { get; }
    ObservableCollection<SupportedLanguage> SupportedLanguages { get; } 
    ObservableCollection<Telemetry> TelemetryData { get; } 
    ObservableCollection<TranslatableString> TranslatableStrings { get; } 
    ObservableCollection<Translation> Translations { get; } 

    public ICommand CreateOsOpDatabaseButtonClick { get; }
    public ICommand ClearOsOpDataButtonClick { get; }
    public ICommand DeleteOsOpDataButtonClick { get; }
    public ICommand GetOsOpDataButtonClick { get; }

}
