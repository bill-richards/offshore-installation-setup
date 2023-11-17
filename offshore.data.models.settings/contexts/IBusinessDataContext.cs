using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings.contexts;

public interface IBusinessDataContext : IOffshoreDbContext
{
    DbSet<Company> Companies { get; }

    DbSet<Contact> Contacts { get; }
    
    DbSet<Address> Addresses { get; }
    DbSet<Country> Countries { get; }
    DbSet<Location> Locations { get; }

    DbSet<TelephoneType> TelephoneTypes { get; }
    DbSet<CountryCode> CountryCodes { get; }
    DbSet<TelephoneNumber> TelephoneNumbers { get; }
}
