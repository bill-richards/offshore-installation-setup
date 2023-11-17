using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.setup.contexts;

public class SetupDataContext : OffshoreDbContext, ISetupDataContext
{
    public SetupDataContext(IOffshoreDbConfiguration databaseConfiguration, string databaseType = "SqlExpress")
        : base(databaseConfiguration, databaseType) { }

    public DbSet<Alarm> Alarms { get; set; }
    public DbSet<Calibration> Calibrations { get; set; }
    public DbSet<ChangeLog> ChangeLogs { get; set; }
    public DbSet<Consignment> Consignments { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<MeasurementUnit> MeasurementsUnits { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<ProfileMeasurementUnits> ProfilesUnits { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<SinglePointMooring> SinglePointsMoorings { get; set; }
    public DbSet<SiteConfiguration> SiteConfigurations { get; set; }
    public DbSet<TelemetryData> TelemetryData { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.HasDefaultSchema(_configFile.SchemataConfiguration.UsersSchema);

        new Alarm().OnModelCreating(modelBuilder);
        new Calibration().OnModelCreating(modelBuilder);
        new ChangeLog().OnModelCreating(modelBuilder);
        new Consignment().OnModelCreating(modelBuilder);
        new Language().OnModelCreating(modelBuilder);
        new Measurement().OnModelCreating(modelBuilder);
        new MeasurementUnit().OnModelCreating(modelBuilder);
        new Module().OnModelCreating(modelBuilder);
        new Profile().OnModelCreating(modelBuilder);
        new ProfileMeasurementUnits().OnModelCreating(modelBuilder);
        new Report().OnModelCreating(modelBuilder);
        new Sensor().OnModelCreating(modelBuilder);
        new SinglePointMooring().OnModelCreating(modelBuilder);
        new SiteConfiguration().OnModelCreating(modelBuilder);
        new TelemetryData().OnModelCreating(modelBuilder);

    }
}
