using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.parsing.models;

namespace offshore.data.parsing.loading;

public static class CompanyDetailsEntityLoader
{
    private static readonly Dictionary<string, Name> Names = [];
    private static readonly Dictionary<string, EmailJsonModel> Emails = [];

    private static readonly Dictionary<string, OffshoreDataModel> ModelReferences = [];

    private static void AddBasicRecords(ICompleteDataContext context, in JsonSiteModel data)
    {
        Names.Clear();
        Emails.Clear();
        ModelReferences.Clear();

        foreach (var item in data.Names!)
            Names.Add(item.Reference!, item);
        foreach (var item in data.Emails!)
            Emails.Add(item.Reference!, item);

        foreach (var language in data.Languages!)
        {
            var existing = context.GetNamedRecord<Language>(language.Name!);
            if (existing is null)
            {
                context.AddToDbSet(language);
                existing = context.LocalView<Language>().GetNamedRecord(language.Name!);
            }

            if (!ModelReferences.ContainsKey(language.Reference))
                ModelReferences.Add(language.Reference!, existing);

        }
        foreach (var item in data.Countries!)
        {
            var existing = context.GetNamedRecord<Country>(item.Name!);
            if (existing is null)
            {
                context.AddToDbSet<Country>(item);
                existing = context.LocalView<Country>()
                                                            .GetNamedRecord(item.Name!);
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference!, existing);
        }
        foreach (var item in data.TelephoneTypes!)
        {
            var existing = context.GetNamedRecord<TelephoneType>(item.Name!);
            if (existing is null)
            {
                context.AddToDbSet(item);
                existing = context.LocalView<TelephoneType>()
                                                            .GetNamedRecord(item.Name!);
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference!, existing);
        }

        foreach (var item in data.CountryCodes)
        {
            var country = ModelReferences[item.CountryRef];
            var existing = context.FirstOrDefault<CountryCode>(c => c.Country!.Equals(country));
            if (existing is null)
            {
                item.Country = country as Country;
                context.AddToDbSet<CountryCode>(item);
                existing = context.LocalView<CountryCode>()!
                                                         .FirstOrDefault(c => c.Country!.Equals(country))!;
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference!, existing);
        }

        foreach (var item in data.Receivers)
        {
            var existing = context.GetNamedRecord<Receiver>(item.Name);
            if (existing is null)
            {
                context.AddToDbSet<Receiver>(item);
                existing = context.LocalView<Receiver>()!
                                                         .GetNamedRecord(item.Name)!;
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference!, existing);
        }

        if (context.ChangeTracker.HasChanges())
            context.SaveChanges();

    }

    public static void PopulateDatabase(ICompleteDataContext context, in JsonSiteModel data)
    {
        AddBasicRecords(context, in data);

        foreach (var item in data.TelephoneNumbers)
        {
            var existing = context.FirstOrDefault<TelephoneNumber>(t => t.Number == item.Number);
            if (existing is null)
            {
                item.CountryCode = (ModelReferences[item.CountryCodeReference] as CountryCode)!;
                item.Type = (ModelReferences[item.TypeReference] as TelephoneType)!;

                context.AddToDbSet<TelephoneNumber>(item);
                existing = context.LocalView<TelephoneNumber>()!
                                                        .FirstOrDefault(t => t.Number == item.Number)!;
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference, existing);
        }

        foreach (var item in data.Addresses)
        {
            var existing = context.FirstOrDefault<Address>(a => a.PostCode == item.PostCode && a.Line1 == item.Line1);
            if (existing is null)
            {
                item.Country = (ModelReferences[item.CountryReference] as Country)!;
                context.AddToDbSet<Address>(item);
                existing = context.LocalView<Address>()
                                                        .FirstOrDefault(a => a.PostCode == item.PostCode && a.Line1 == item.Line1);
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference, existing!);
        }

        foreach (var item in data.Contacts)
        {
            var contact = context.GetNamedRecord<Contact>(Names[item.NameReference].Value);
            if (contact is null)
            {
                item.Name = Names[item.NameReference].Value;
                foreach (var reference in item.TelephoneReferences)
                {
                    var number = ModelReferences[reference] as TelephoneNumber;
                    item.TelephoneNumbers.Add(number!);
                }
                context.AddToDbSet<Contact>(item);
                contact = context.LocalView<Contact>()!.GetNamedRecord(item.Name);
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference, contact);
        }

        foreach (var item in data.Locations)
        {
            var location = context.GetNamedRecord<Location>(item.Name!);
            if (location is null)
            {
                item.Address = (ModelReferences[item.AddressReference] as Address)!;
                foreach (var reference in item.ContactReferences!)
                {
                    var contact = ModelReferences[reference] as Contact;
                    item.Contacts.Add(contact!);
                }
                context.AddToDbSet<Location>(item);
                location = context.LocalView<Location>()!.GetNamedRecord(item.Name);
            }
            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference, location!);
        }

        foreach (var item in data.Companies)
        {
            var existing = context.GetNamedRecord<Company>(item.Name);
            if (existing is null)
            {
                item.Location = ModelReferences[item.LocationReference] as Location;
                context.AddToDbSet<Company>(item);
                existing = context.LocalView<Company>()!.GetNamedRecord(item.Name);
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference, existing);
        }

        foreach (var item in data.Users)
        {
            var existing = context.GetNamedRecord<User>(Names[item.NameReference].Value);
            if (existing is null)
            {
                item.Name = Names[item.NameReference].Value;
                item.Email = Emails[item.EmailReference].Value;
                foreach (var language in item.LanguageReferences)
                {
                    item.Languages.Add((ModelReferences[language] as Language)!);
                }

                foreach (var role in item.RoleReferences) { item.Roles.Add(context.GetNamedRecord<Role>(role)); }

                foreach (var telephone in item.TelephoneReferences)
                {
                    item.TelephoneNumbers.Add((ModelReferences[telephone] as TelephoneNumber)!);
                }

                context.AddToDbSet<User>(item);
                existing = context.LocalView<User>().GetNamedRecord(item.Name);
            }

            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference, existing);
        }

        foreach (var item in data.SiteConfigurations)
        {
            item.Name = Names[item.NameReference].Value;

            var existing = context.GetNamedRecord<SiteConfiguration>(item.Name);
            if (existing is null)
            {
                item.SyncUser = ModelReferences[item.UserReference] as User
                                ?? context.GetNamedRecord<User>(item.UserReference);
                item.ReceiverType = ModelReferences[item.ReceiverTypeReference] as Receiver;
                context.AddToDbSet<SiteConfiguration>(item);

                existing = context.LocalView<SiteConfiguration>()!.GetNamedRecord(item.Name);
            }
            if (!ModelReferences.ContainsKey(item.Reference))
                ModelReferences.Add(item.Reference, existing);
        }

        foreach (var item in data.Sites)
        {
            item.Name = Names[item.NameReference].Value;

            var existing = context.GetNamedRecord<Site>(item.Name);
            if(existing is null)
            {
                item.Company = ModelReferences[item.CompanyReference]! as Company;
                item.Location = ModelReferences[item.LocationReference]! as Location;
                item.Configuration = ModelReferences[item.ConfigurationReference]! as SiteConfiguration;

                context.AddToDbSet<Site>(item);
                existing = context.LocalView<Site>().GetNamedRecord(item.Name);
                foreach (var userRef in item.UserReferences)
                {
                    var user = ModelReferences[userRef] as User;
                    var siteUser = context.FirstOrDefault<SiteUser>(s => s.Site == existing && s.User == user);
                    if (siteUser is null)
                    {
                        context.AddToDbSet(new SiteUser { Site = existing, User = user });
                        siteUser = context.LocalView<SiteUser>().FirstOrDefault(s => s.Site == existing && s.User == user);
                    }
                    existing.Users.Add(siteUser!);
                }
            }


        }

        if (context.ChangeTracker.HasChanges())
            context.SaveChanges();
    }
}