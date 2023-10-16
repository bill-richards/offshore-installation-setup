using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings.contexts;

public class SettingsDataContext : OffshoreDbContext, ISettingsDataContext
{
    public SettingsDataContext(IOffshoreDbConfiguration databaseConfiguration, string databaseType = "SqlExpress", bool create = true)
        : base(databaseConfiguration, databaseType, create) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => DatabaseConfiguration.OnConfiguring(optionsBuilder);

    public override int SaveChanges() => base.SaveChanges();

    public DbSet<Alarm> Alarms { get; set; }
    public DbSet<Calibration> Calibrations { get; set; }
    public DbSet<ChangeLog> ChangeLogs { get; set; }
    public DbSet<Consignment> Consignments { get; set; }
    public DbSet<LiveDatum> LiveData { get; set; }
    public DbSet<MeasurementDataUnit> MeasurementDataUnits { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<ReceivedData> ReceivedData { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<SinglePointMooring> SinglePointMoorings { get; set; }
    public DbSet<SinglePointMooringModule> SinglePointMooringModules { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<SiteConfiguration> SiteConfigurations { get; set; }
    public DbSet<SiteMeasurementDataUnit> SiteMeasurementDataUnits { get; set; }
    public DbSet<SupportedLanguage> Languages { get; set; }
    public DbSet<Telemetry> TelemetryData { get; set; }
    public DbSet<Translatable> Translatables { get; set; }
    public DbSet<Translation> Translations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new Alarm().OnModelCreating(modelBuilder);
        new Calibration().OnModelCreating(modelBuilder);
        new ChangeLog().OnModelCreating(modelBuilder);
        new Consignment().OnModelCreating(modelBuilder);
        new LiveDatum().OnModelCreating(modelBuilder);
        new MeasurementDataUnit().OnModelCreating(modelBuilder);
        new Measurement().OnModelCreating(modelBuilder);
        new MeasurementUnit().OnModelCreating(modelBuilder);
        new Module().OnModelCreating(modelBuilder);
        new ReceivedData().OnModelCreating(modelBuilder);
        new Sensor().OnModelCreating(modelBuilder);
        new SinglePointMooring().OnModelCreating(modelBuilder);
        new SinglePointMooringModule().OnModelCreating(modelBuilder);
        new Site().OnModelCreating(modelBuilder);
        new SiteConfiguration().OnModelCreating(modelBuilder);
        new SiteMeasurementDataUnit().OnModelCreating(modelBuilder);
        new SupportedLanguage().OnModelCreating(modelBuilder);
        new Telemetry().OnModelCreating(modelBuilder);
        new Translatable().OnModelCreating(modelBuilder);
        new Translation().OnModelCreating(modelBuilder);
    }
}
