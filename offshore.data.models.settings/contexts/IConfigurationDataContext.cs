using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings.contexts;

public interface IConfigurationDataContext : IOffshoreDbContext
{
    DbSet<Alarm> Alarms { get; }
    DbSet<Calibration> Calibrations { get; }
    DbSet<ChangeLog> ChangeLogs { get; }
    DbSet<Consignment> Consignments { get; }
    DbSet<LiveDatum> LiveData { get; }
    DbSet<MeasurementType> MeasurementTypes { get; }
    DbSet<MeasurementUnit> MeasurementUnits { get; }
    DbSet<Module> Modules { get; }
    DbSet<Receiver> Receivers { get; }
    DbSet<ReceivedData> ReceivedData { get; }
    DbSet<Sensor> Sensors { get; }
    DbSet<SinglePointMooring> SinglePointMoorings { get; }
    DbSet<Site> Sites { get; }
    DbSet<SiteConfiguration> SiteConfigurations { get; }
    DbSet<SiteMeasurementUnit> SiteMeasurementUnits { get; }
    DbSet<Telemetry> TelemetryData { get; }
}
