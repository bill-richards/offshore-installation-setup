using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.parsing.models.loading;

namespace offshore.data.parsing.loading;

public static class TelephonyEntityLoader
{
    public static void PopulateDatabase(IBusinessDataContext context, in TelephonyDataEntities data)
    {
        if (context.GetNamedRecord<Country>(data.Countries[0].Name!) is null)
        {
            context.AddRangeToDbSet(data.Countries!);
            context.SaveChanges();
        }

        if (context.GetNamedRecord<TelephoneType>(data.TelephoneTypes[0].Name!) is null)
        {
            context.AddRangeToDbSet(data.TelephoneTypes!);
        }

        var reference = data.CountryCodes[0].CountryRef;
        if (!context.GetDbSet<CountryCode>().Any(c => c.Country!.Name == reference))
        {
            foreach (var code in data.CountryCodes)
            {
                code.Country = context.GetNamedRecord<Country>(code.CountryRef!);
            }
            context.AddRangeToDbSet(data.CountryCodes!);
        }

        if (context.ChangeTracker.HasChanges())
            context.SaveChanges();
    }
}
