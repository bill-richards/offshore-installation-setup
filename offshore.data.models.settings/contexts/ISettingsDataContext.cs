using Microsoft.EntityFrameworkCore;
using offshore.data.models.settings;

namespace offshore.data.sqlite.contexts
{
    public interface ISettingsDataContext : IOffshoreDbContext
    {
        DbSet<Alarm> Alarms { get; set; }
        DbSet<Calibration> Calibrations { get; set; }
        DbSet<ChangeLog> ChangeLogs { get; set; }
        DbSet<Consignment> Consignments { get; set; }
        DbSet<LiveDatum> LiveData { get; set; }
        DbSet<Measurement> Measurements { get; set; }
        DbSet<MeasurementDataUnit> MeasurementDataUnits { get; set; }
        DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        DbSet<Module> Modules { get; set; }
        DbSet<ReceivedData> ReceivedData { get; set; }
        DbSet<Sensor> Sensors { get; set; }
        DbSet<SinglePointMooring> SinglePointMoorings { get; set; }
        DbSet<SinglePointMooringModule> SinglePointMooringModules { get; set; }
        DbSet<Site> Sites { get; set; }
        DbSet<SiteConfiguration> SiteConfigurations { get; set; }
        DbSet<SiteMeasurementDataUnit> SiteMeasurementDataUnits { get; set; }
        DbSet<SupportedLanguage> SupportedLanguages { get; set; }
        DbSet<Telemetry> TelemetryData { get; set; }
        DbSet<TranslatableString> TranslatableStrings { get; set; }
        DbSet<Translation> Translations { get; set; }
    }
}