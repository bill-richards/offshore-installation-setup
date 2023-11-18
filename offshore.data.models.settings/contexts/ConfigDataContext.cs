using Microsoft.EntityFrameworkCore;
using offshore.services;

namespace offshore.data.models.settings.contexts;

public class ConfigDataContext : OffshoreDbContext, IConfigurationDataContext
{
    private readonly IDatabaseConfigurationFile _configFile;

    public ConfigDataContext(IConfigurationSchema databaseConfiguration, IDatabaseConfigurationFile configFile, string databaseType = "SqlExpress")
        : base(databaseConfiguration, databaseType)
    {
        _configFile = configFile;
    }

    public DbSet<Alarm> Alarms { get; set; }
    public DbSet<Calibration> Calibrations { get; set; }
    public DbSet<ChangeLog> ChangeLogs { get; set; }
    public DbSet<Consignment> Consignments { get; set; }
    public DbSet<LiveDatum> LiveData { get; set; }
    public DbSet<MeasurementType> MeasurementTypes { get; set; }
    public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<ReceivedData> ReceivedData { get; set; }
    public DbSet<Receiver> Receivers { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<SinglePointMooring> SinglePointMoorings { get; set; }
    public DbSet<SiteConfiguration> SiteConfigurations { get; set; }
    public DbSet<SiteMeasurementUnit> SiteMeasurementUnits { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<Telemetry> TelemetryData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_configFile.SchemataConfiguration.ConfigurationSchema);

        new Alarm().OnModelCreating(modelBuilder);
        new Calibration().OnModelCreating(modelBuilder);
        new ChangeLog().OnModelCreating(modelBuilder);
        new Consignment().OnModelCreating(modelBuilder);
        new LiveDatum().OnModelCreating(modelBuilder);
        new MeasurementType().OnModelCreating(modelBuilder);
        new MeasurementUnit().OnModelCreating(modelBuilder);
        new Module().OnModelCreating(modelBuilder);
        new ReceivedData().OnModelCreating(modelBuilder);
        new Receiver().OnModelCreating(modelBuilder);
        new Sensor().OnModelCreating(modelBuilder);
        new SinglePointMooring().OnModelCreating(modelBuilder);
        new Site().OnModelCreating(modelBuilder);
        new SiteConfiguration().OnModelCreating(modelBuilder);
        new SiteMeasurementUnit().OnModelCreating(modelBuilder);
        new Telemetry().OnModelCreating(modelBuilder);
    }
}
