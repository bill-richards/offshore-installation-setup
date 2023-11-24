using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings.defaults;

public static class PermissionsAndRolesSetup
{
    public static void PopulateDatabase(IUserDataContext usersContext, 
                                        IConfigurationDataContext settingsContext)
    {
        var readPermission = usersContext.GetReadPermissions();
        var allPermission = usersContext.GetAllPermissions();
        var sitePermission = usersContext.GetSitePermissions();
        var consignmentPermission = usersContext.GetConsignmentPermissions();

        var syncRole = usersContext.GetSyncRole().SetPermissions(readPermission).And.SetWeight(0);
        var sysAdminRole = usersContext.GetSysAdminRole().SetPermissions(allPermission).And.SetWeight(5);
        var siteAdminRole = usersContext.GetSiteAdminRole().SetPermissions(sitePermission).And.SetWeight(10);
        var pilotRole = usersContext.GetPilotRole().SetPermissions(consignmentPermission).And.SetWeight(14);
        var userRole = usersContext.GetUserRole().SetPermissions(readPermission).And.SetWeight(15);


        //syncRole.SetPermissions(readPermission).And.SetWeight(0);
        //sysAdminRole.SetPermissions(allPermission).And.SetWeight(5);
        //siteAdminRole.SetPermissions(sitePermission).And.SetWeight(10);
        //pilotRole.SetPermissions(consignmentPermission).And.SetWeight(14);
        //userRole.SetPermissions(readPermission).And.SetWeight(15);

        usersContext.SaveChanges();

        Site syncSite = new() { Name = "SYNC_SETUP", IsDefault = true };
        var existingSite = settingsContext.GetNamedRecord<Site>(syncSite.Name);
        if (existingSite == null)
        {
            settingsContext.AddToDbSet(syncSite).And.SaveChanges();
        }

        
        if (settingsContext.GetNamedRecord<User>("sa") is null)
        {
            var language = settingsContext.GetNamedRecord<Language>("en");
            if (language is null)
            {
                language = new()
                {
                    Display = "English",
                    Name = "en",
                    IsDefault = true
                };
                settingsContext.AddToDbSet(language);

                language = settingsContext.LocalView<Language>().GetNamedRecord("en");
            }

            Role role = settingsContext.GetNamedRecord<Role>(syncRole.Name!);
            settingsContext.AddToDbSet(new User()
            {
                Name = "sa",
                Roles = new[] { role },
                Languages = new[] { language! },
                IsDefault = true
            }).And.SaveChanges();
        }

        if (settingsContext.ChangeTracker.HasChanges())
            settingsContext.SaveChanges();

    }
}
