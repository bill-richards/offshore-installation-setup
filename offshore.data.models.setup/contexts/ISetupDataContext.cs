using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.setup.contexts
{
    public interface ISetupDataContext : IOffshoreDbContext
    {
        DbSet<Alarm> Alarms { get; set; }
        DbSet<Calibration> Calibrations { get; set; }
        DbSet<ChangeLog> ChangeLogs { get; set; }
        DbSet<Consignment> Consignments { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Measurement> Measurements { get; set; }
        DbSet<MeasurementUnit> MeasurementsUnits { get; set; }
        DbSet<Module> Modules { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<ProfileMeasurementUnits> ProfilesUnits { get; set; }
        DbSet<Report> Reports { get; set; }
        DbSet<Sensor> Sensors { get; set; }
        DbSet<SinglePointMooring> SinglePointsMoorings { get; set; }
        DbSet<SiteConfiguration> SiteConfigurations { get; set; }
        DbSet<TelemetryData> TelemetryData { get; set; }
    }
}