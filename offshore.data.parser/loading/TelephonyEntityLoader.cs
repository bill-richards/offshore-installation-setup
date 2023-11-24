using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.parsing.models;

namespace offshore.data.parsing.loading;

public static class TelephonyEntityLoader
{
    public static void PopulateDatabase(IBusinessDataContext context, in DefaultTelephonyDataModel data)
    {
        if (context.GetNamedRecord<data.models.settings.Country>(data.Countries![0].Name!) is null)
            context.AddRangeToDbSet(data.Countries).And.SaveChanges();

        if (context.GetNamedRecord<data.models.settings.TelephoneType>(data.TelephoneTypes![0].Name!) is null)
            context.AddRangeToDbSet(data.TelephoneTypes).And.SaveChanges();

        var reference = data.CountryCodes![0].CountryRef;
        if (!context.GetDbSet<data.models.settings.CountryCode>().Any(c => c.Country!.Name == reference))
        {
            foreach (var code in data.CountryCodes)
            {
                code.Country = context.GetNamedRecord<data.models.settings.Country>(code.CountryRef!);
            }

            context.AddRangeToDbSet(data.CountryCodes!).And.SaveChanges();
        }
    }
}
