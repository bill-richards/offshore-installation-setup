using Microsoft.EntityFrameworkCore;
using offshore.services;

namespace offshore.data.models.settings.contexts;

public class CompleteDataContext : OffshoreDbContext, ICompleteDataContext
{
    private readonly IDataConfigurationFile _configFile;

    public CompleteDataContext(ISettingsSchema databaseConfiguration, IDataConfigurationFile configFile, string databaseType = "SqlExpress")
        : base(databaseConfiguration, databaseType)
    {
        _configFile = configFile;
    }

    /* config Schema */

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

    /* From the biz Schema */
    public DbSet<Company> Companies { get; init; }
    public DbSet<Contact> Contacts { get; init; }
    public DbSet<Address> Addresses { get; init; }
    public DbSet<Country> Countries { get; init; }
    public DbSet<Location> Locations { get; init; }
    public DbSet<TelephoneType> TelephoneTypes { get; init; }
    public DbSet<CountryCode> CountryCodes { get; init; }
    public DbSet<TelephoneNumber> TelephoneNumbers { get; init; }

    /* User Schema */
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    /* Language Schema */
    public DbSet<Language> Languages { get; set; }
    public DbSet<Translatable> Translatables { get; set; }
    public DbSet<Translation> Translations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_configFile.SchemataConfiguration.SettingsSchema);

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

        new Company().OnModelCreating(modelBuilder);
        new Contact().OnModelCreating(modelBuilder);
        new Address().OnModelCreating(modelBuilder);
        new Country().OnModelCreating(modelBuilder);
        new Location().OnModelCreating(modelBuilder);
        new CountryCode().OnModelCreating(modelBuilder);
        new TelephoneType().OnModelCreating(modelBuilder);
        new TelephoneNumber().OnModelCreating(modelBuilder);

        new Permission().OnModelCreating(modelBuilder);
        new Role().OnModelCreating(modelBuilder);
        new User().OnModelCreating(modelBuilder);

        new Language().OnModelCreating(modelBuilder);
        new Translatable().OnModelCreating(modelBuilder);
        new Translation().OnModelCreating(modelBuilder);
    }
}
