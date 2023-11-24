using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.parsing.models;

namespace offshore.data.parsing.loading;

public static class CompanyDetailsEntityLoader
{
    private static readonly Dictionary<string, Name> Names = [];
    private static readonly Dictionary<string, Email> Emails = [];
    
    private static readonly Dictionary<string, OffshoreDataModel> ModelReferences = [];

    private static void AddBasicRecords(ICompleteDataContext context, in CompanyDataModel data)
    {
        foreach (var language in data.Languages!)
        {
            if (context.GetNamedRecord<data.models.settings.Language>(language.Name!) is null)
            {
                context.AddToDbSet(language);
            }

            ModelReferences.Add(language.Reference!, context.LocalView<data.models.settings.Language>().GetNamedRecord(language.Name!));

        }
        foreach (var item in data.Countries!)
        {
            if (context.GetNamedRecord<data.models.settings.Country>(item.Name!) is null)
                context.AddToDbSet(item);

            ModelReferences.Add(item.Reference!, context.LocalView<data.models.settings.Country>().GetNamedRecord(item.Name!));
        }
        foreach (var item in data.TelephoneTypes!)
        {
            if (context.GetNamedRecord<data.models.settings.TelephoneType>(item.Name!) is null)
                context.AddToDbSet(item);

            ModelReferences.Add(item.Reference!, context.LocalView<data.models.settings.TelephoneType>().GetNamedRecord(item.Name!));
        }

        if (context.ChangeTracker.HasChanges())
            context.SaveChanges();

        foreach (var item in data.Names!)
            Names.Add(item.Reference!, item);
        foreach (var item in data.Emails!)
            Emails.Add(item.Reference!, item);
    }

    public static void PopulateDatabase(ICompleteDataContext context, in CompanyDataModel data)
    {
        AddBasicRecords(context, in data);

        foreach (var item in data.CountryCodes)
        {
            var country = ModelReferences[item.CountryRef];
            if (context.FirstOrDefault<data.models.settings.CountryCode>(c => c.Country!.Equals(country)) is null)
                context.AddToDbSet<data.models.settings.CountryCode>(item);


            ModelReferences.Add(item.Reference!, context.LocalView<data.models.settings.CountryCode>()!
                                                         .FirstOrDefault(c => c.Country!.Equals(country))!);
        }

        foreach (var item in data.TelephoneNumbers)
        {
            var existing = context.FirstOrDefault<data.models.settings.TelephoneNumber>(t => t.Number == item.Number);
            if (existing is null)
            {
                item.CountryCode = (ModelReferences[item.CountryCodeReference] as data.models.settings.CountryCode)!;
                item.Type = (ModelReferences[item.TypeReference] as data.models.settings.TelephoneType)!;

                context.AddToDbSet<data.models.settings.TelephoneNumber>(item);
                existing = context.LocalView<data.models.settings.TelephoneNumber>()!
                                                        .FirstOrDefault(t => t.Number == item.Number)!;
            }

            ModelReferences.Add(item.Reference, existing);
        }

        foreach (var item in data.Addresses)
        {
            var existing = context.FirstOrDefault<data.models.settings.Address>(a => a.PostCode == item.PostCode && a.Line1 == item.Line1);
            if (existing is null)
            {
                item.Country = (ModelReferences[item.CountryReference] as data.models.settings.Country)!;
                context.AddToDbSet<data.models.settings.Address>(item);
                existing = context.LocalView<data.models.settings.Address>()
                                                        .FirstOrDefault(a => a.PostCode == item.PostCode && a.Line1 == item.Line1);
            }

            ModelReferences.Add(item.Reference, existing!);
        }

        foreach (var item in data.Contacts)
        {
            var contact = context.GetNamedRecord<data.models.settings.Contact>(Names[item.NameReference].Value);
            if (contact is null)
            {
                item.Name = Names[item.NameReference].Value;
                foreach (var reference in item.TelephoneReferences)
                {
                    var number = ModelReferences[reference] as data.models.settings.TelephoneNumber;
                    item.TelephoneNumbers.Add(number!);
                }
                context.AddToDbSet<data.models.settings.Contact>(item);
                contact = context.LocalView<data.models.settings.Contact>()!.GetNamedRecord(item.Name);
            }

            ModelReferences.Add(item.Reference, contact);
        }

        foreach (var item in data.Locations)
        {
            var location = context.GetNamedRecord<data.models.settings.Location>(item.Name!);
            if (location is null)
            {
                item.Address = (ModelReferences[item.AddressReference] as data.models.settings.Address)!;
                foreach (var reference in item.ContactReferences!)
                {
                    var contact = ModelReferences[reference] as data.models.settings.Contact;
                    item.Contacts.Add(contact!);
                }
                context.AddToDbSet<data.models.settings.Location>(item);
                location = context.LocalView<data.models.settings.Location>()!.GetNamedRecord(item.Name);
            }
            ModelReferences.Add(item.Reference, location!);
        }

        foreach (var item in data.Companies)
        {
            var company = context.GetNamedRecord<data.models.settings.Company>(item.Name);
            if (company is null)
            {
                item.Location = ModelReferences[item.LocationReference] as data.models.settings.Location;
                context.AddToDbSet<data.models.settings.Company>(item);
                company = context.LocalView<data.models.settings.Company>()!.GetNamedRecord(item.Name);
            }
        }

        foreach (var item in data.Users)
        {
            var user = context.GetNamedRecord<data.models.settings.User>(Names[item.NameReference].Value);
            if (user is null)
            {
                item.Name = Names[item.NameReference].Value;
                item.Email = Emails[item.EmailReference].Value;
                foreach (var language in item.LanguageReferences) { 
                    item.Languages.Add((ModelReferences[language] as data.models.settings.Language)!); }
                
                foreach (var role in item.RoleReferences) { item.Roles.Add(context.GetNamedRecord<Role>(role)); }
                
                foreach (var telephone in item.TelephoneReferences) { 
                    item.TelephoneNumbers.Add((ModelReferences[telephone] as data.models.settings.TelephoneNumber)!); }

                context.AddToDbSet<data.models.settings.User>(item);
            }
        }

        if (context.ChangeTracker.HasChanges())
            context.SaveChanges();
    }
}