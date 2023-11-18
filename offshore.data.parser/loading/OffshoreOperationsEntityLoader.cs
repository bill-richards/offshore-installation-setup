using offshore.data.models.settings;
using offshore.data.models.settings.contexts;

namespace offshore.data.parsing.loading;

public static class OffshoreOperationsEntityLoader
{
    public static void PopulateDatabase(ICompleteDataContext settings)
    {
        const string name = "Paul Wartnarby";
        const string company = "Offshore Operations Limited";
        const string email = "paul@offshoreops.com";
        const ulong mobileNumber = 7502034566;

        var England = settings.GetNamedRecord<Country>("England");
        var mobilePhone = settings.GetNamedRecord<TelephoneType>("mobile");
        var language = settings.GetNamedRecord<Language>("en");


        if (settings.FirstOrDefault<TelephoneNumber>(t => t.Number == mobileNumber) is null)
        {
            settings.AddToDbSet<TelephoneNumber>(new()
            {
                CountryCode = settings.FirstOrDefault<CountryCode>(c => c.Country == England),
                Number = mobileNumber,
                Type = mobilePhone,
                IsDefault = true
            });
            settings.SaveChanges();
        }

        var mobile = settings.FirstOrDefault<TelephoneNumber>(t => t.Number == mobileNumber);
        if (settings.GetNamedRecord<Contact>(name) is null)
        {
            settings.AddToDbSet<Contact>(new()
            {
                Name = name,
                JobTitle = "Managing Director",
                TelephoneNumber = mobile,
                IsDefault = true
            });
            settings.SaveChanges();
        }

        Location oOpsLocation = new()
        {
            Name = "Off-Ops Head Office",
            Address = new()
            {
                Line1 = "144 Chelveston Crescent",
                City = "Southampton",
                County = "Hampshire",
                PostCode = "SO16 5SD",
                Country = England,
                IsDefault = true
            },
            Contacts = new[] { settings.GetNamedRecord<Contact>(name) },
            IsDefault = true
        };
        if (settings.GetNamedRecord<Location>(oOpsLocation.Name) is null)
        {
            settings.AddToDbSet(oOpsLocation);
            settings.SaveChanges();
        }
        oOpsLocation = settings.GetNamedRecord<Location>(oOpsLocation.Name);

        if (settings.GetNamedRecord<Company>(company) is null)
        {
            settings.AddToDbSet<Company>(new()
            {
                Name = company,
                Location = oOpsLocation,
                IsDefault = true
            });
            settings.SaveChanges();
        }

        if (settings.GetNamedRecord<User>(name) is null)
        {
            settings.AddToDbSet(new User
            {
                Name = name,
                Languages = new[] { language },
                Roles = new[] { settings.GetSysAdminRole(), settings.GetSiteAdminRole() },
                Email = email,
                TelephoneNumbers = new[] { mobile },
                IsDefault = true
            });

            settings.SaveChanges();
        }

    }
}
