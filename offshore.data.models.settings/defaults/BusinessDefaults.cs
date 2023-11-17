using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings.defaults;

public static class BusinessDefaults
{
    public static void PopulateDatabase(IBusinessDataContext context)
    {
        Country England = new() { Name = "England", IsDefault = true };
        var existing = context.GetNamedRecord<Country>(England.Name);
        if (existing is not null) England = existing;

        Country Ireland = new() { Name = "Republic of Ireland", IsDefault = true };
        existing = context.GetNamedRecord<Country>(Ireland.Name);
        if (existing is not null) Ireland = existing;
        Country Scotland = new() { Name = "Scotland", IsDefault = true };
        existing = context.GetNamedRecord<Country>(Scotland.Name);
        if (existing is not null) Scotland = existing;
        Country Wales = new() { Name = "Wales", IsDefault = true };
        existing = context.GetNamedRecord<Country>(Wales.Name);
        if (existing is not null) Wales = existing;
        Country Spain = new() { Name = "Spain", IsDefault = true };
        existing = context.GetNamedRecord<Country>(Spain.Name);
        if (existing is not null) Spain = existing;

        if (context.GetNamedRecord<TelephoneType>("mobile") is null)
        {
            context.AddRangeToDbSet(new[]
            {
                new TelephoneType { Name = "mobile", IsDefault = true },
                new TelephoneType { Name = "land-line", IsDefault = true },
            });
        }
        if (context.FirstOrDefaultWithNavigationProperty<CountryCode>("Country", c => c.Country == England) is null)
            context.AddToDbSet(new CountryCode { DialingCode = "+44", Country = England, IsDefault = true });
        if (context.FirstOrDefaultWithNavigationProperty<CountryCode>("Country", c => c.Country == Ireland) is null)
            context.AddToDbSet(new CountryCode { DialingCode = "+353", Country = Ireland, IsDefault = true });
        if (context.FirstOrDefaultWithNavigationProperty<CountryCode>("Country", c => c.Country == Scotland) is null)
            context.AddToDbSet(new CountryCode { DialingCode = "+44", Country = Scotland, IsDefault = true });
        if (context.FirstOrDefaultWithNavigationProperty<CountryCode>("Country", c => c.Country == Wales) is null)
            context.AddToDbSet(new CountryCode { DialingCode = "+44", Country = Wales, IsDefault = true });
        if (context.FirstOrDefaultWithNavigationProperty<CountryCode>("Country", c => c.Country == Spain) is null)
            context.AddToDbSet(new CountryCode { DialingCode = "+36", Country = Spain, IsDefault = true });

        context.SaveChanges();
    }
}
