using Microsoft.EntityFrameworkCore;
using offshore.services;

namespace offshore.data.models.settings.contexts;

public class BusinessDataContext : OffshoreDbContext, IBusinessDataContext
{
    private readonly IDataConfigurationFile _configFile;
    public BusinessDataContext(IBusinessSchema databaseConfiguration, IDataConfigurationFile configFile, string databaseType = "SqlExpress") 
        : base(databaseConfiguration, databaseType)
    {
        _configFile = configFile;
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<TelephoneType> TelephoneTypes { get; set; }
    public DbSet<CountryCode> CountryCodes { get; set; }
    public DbSet<TelephoneNumber> TelephoneNumbers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_configFile.SchemataConfiguration.BusinessSchema);

        new Company().OnModelCreating(modelBuilder);
        new Contact().OnModelCreating(modelBuilder);
        new Address().OnModelCreating(modelBuilder);

        new Country().OnModelCreating(modelBuilder);
        new Location().OnModelCreating(modelBuilder);

        new CountryCode().OnModelCreating(modelBuilder);
        new TelephoneType().OnModelCreating(modelBuilder);
        new TelephoneNumber().OnModelCreating(modelBuilder);
    }
}
