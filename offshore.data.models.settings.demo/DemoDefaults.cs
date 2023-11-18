using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings.defaults;

public static class DemoDefaults
{
    const string siteName = "Example-Site";
    const string paulWartnarby = "Paul Wartnarby";
    const string companyName = "Example-Company";

    public static void PopulateDatabase(ICompleteDataContext settings)
    {
        const string exampleUserName = $"{siteName} User";
        const string exampleAdminName = $"{siteName} Admin";
        const string exampleSysAdminName = $"{companyName} SysAdmin";
        const string examplePilotName = "Example Pilot";


        Country England = settings.GetNamedRecord<Country>("England");
        Country Ireland = settings.GetNamedRecord<Country>("Republic of Ireland");
        Country Scotland = settings.GetNamedRecord<Country>("Scotland");
        Country Wales = settings.GetNamedRecord<Country>("Wales");

        var mobilePhone = settings.GetNamedRecord<TelephoneType>("mobile");
        var wiredPhone = settings.GetNamedRecord<TelephoneType>("land-line");

        TelephoneNumber usersMobile = new()
        {
            CountryCode = settings.FirstOrDefault<CountryCode>(c => c.Country == England),
            Number = 7399744239,
            Type = mobilePhone
        };
        TelephoneNumber pilotMobile = new()
        {
            CountryCode = settings.FirstOrDefault<CountryCode>(c => c.Country == England),
            Number = 7916164262,
            Type = mobilePhone
        };
        TelephoneNumber usersLandline = new()
        {
            CountryCode = settings.FirstOrDefault<CountryCode>(c => c.Country == Ireland),
            Number = 1420864793,
            Type = wiredPhone
        };
        TelephoneNumber adminLandline = new()
        {
            CountryCode = settings.FirstOrDefault<CountryCode>(c => c.Country == Ireland),
            Number = 1420864794,
            Type = wiredPhone
        };

        if (settings.FirstOrDefault<TelephoneNumber>(t => t.Number == usersMobile.Number) is null)
        {
            settings.AddRangeToDbSet(new[] { /*paulsMobile,*/ usersMobile, pilotMobile, usersLandline, adminLandline });
            settings.SaveChanges();
        }
        usersMobile = settings.FirstOrDefault<TelephoneNumber>(t => t.Number == usersMobile.Number);
        pilotMobile = settings.FirstOrDefault<TelephoneNumber>(t => t.Number == pilotMobile.Number);
        usersLandline = settings.FirstOrDefault<TelephoneNumber>(t => t.Number == usersLandline.Number);
        adminLandline = settings.FirstOrDefault<TelephoneNumber>(t => t.Number == adminLandline.Number);

        Location siteLocation = new()
        {
            Name = $"{siteName} Location",
            Address = new()
            {
                Line1 = "999 Letsbe Avenue",
                City = $"{siteName} City",
                County = $"{siteName} County",
                PostCode = "CO9 54OP",
                Country = Ireland,
            },
            Contacts = new Contact[]
            {
                new()
                {
                    Name = exampleAdminName,
                    JobTitle = $"{siteName} Manager",
                    TelephoneNumber = adminLandline
                }
            },
        };
        if (settings.GetNamedRecord<Location>(siteLocation.Name) is null)
        {
            settings.AddToDbSet(siteLocation);
            settings.SaveChanges();
        }
        siteLocation = settings.GetNamedRecord<Location>(siteLocation.Name);

        Site exampleSite = new() { Name = siteName, Location = siteLocation };
        var existing = settings.GetNamedRecord<Site>(exampleSite.Name);
        if (existing is null)
        {
            settings.AddToDbSet(exampleSite);
            settings.SaveChanges();
            exampleSite = settings.GetNamedRecord<Site>(exampleSite.Name);
        }
        else
            exampleSite = existing;

        Company exampleCompany = new()
        {
            Name = companyName,
            Location = siteLocation,
            Sites = new Site[] { exampleSite }
        };
        if (settings.GetNamedRecord<Company>(exampleCompany.Name) is null)
        {
            settings.AddToDbSet(exampleCompany);
        }
        settings.SaveChanges();
        exampleCompany = settings.GetNamedRecord<Company>(exampleCompany.Name);

        var english = settings.GetNamedRecord<Language>("en");
        var spanish = settings.GetNamedRecord<Language>("es");
        if (settings.GetNamedRecord<User>(examplePilotName) is null)
        {
            settings.AddRangeToDbSet(new[]
            {
                new User
                {
                    Name = examplePilotName,
                    Languages = new [] { english, spanish },
                    Roles = new[] { settings.GetPilotRole() },
                    Email = "pilot@pilot-company.co.uk",
                    TelephoneNumbers = new [] { pilotMobile },
                },
                new User
                {
                    Name = exampleUserName,
                    Languages = new [] { spanish },
                    Roles = new[] { settings.GetUserRole() },
                    Email = "user@example-company.co.uk",
                    TelephoneNumbers = new [] { usersMobile, usersLandline },
                },
                new User
                {
                    Name = exampleAdminName,
                    Languages = new [] { english, spanish },
                    Roles = new[] { settings.GetSiteAdminRole(), settings.GetUserRole() },
                    Email = "site-admin@example-company.co.uk",
                    TelephoneNumbers = new [] { adminLandline },
                },
                new User
                {
                    Name = exampleSysAdminName,
                    Languages = new [] { english, spanish },
                    Roles = new[] { settings.GetSiteAdminRole(), settings.GetSysAdminRole() },
                    Email = "system-admin@example-company.co.uk",
                    TelephoneNumbers = new [] { adminLandline },
                }
            });

            settings.SaveChanges();
        }

        var site = settings.GetNamedRecordWithNavigationProperties<Site>(siteName);

        if (!site.Users.Contains(settings.GetNamedRecord<User>(exampleUserName)))
            site.Users.Add(settings.GetNamedRecord<User>(exampleUserName));
        if (!site.Users.Contains(settings.GetNamedRecord<User>(exampleAdminName)))
            site.Users.Add(settings.GetNamedRecord<User>(exampleAdminName));
        if (!site.Users.Contains(settings.GetNamedRecord<User>(examplePilotName)))
            site.Users.Add(settings.GetNamedRecord<User>(examplePilotName));

        if (!site.Users.Contains(settings.GetNamedRecord<User>(paulWartnarby)))
            site.Users.Add(settings.GetNamedRecord<User>(paulWartnarby));

        settings.SaveChanges();
    }
}
