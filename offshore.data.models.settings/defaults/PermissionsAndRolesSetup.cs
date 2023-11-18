using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings.defaults;

public static class PermissionsAndRolesSetup
{
    public static void PopulateDatabase(IUserDataContext usersContext, 
                                        IConfigurationDataContext settingsContext)
    {
        var syncRole = usersContext.GetSyncRole();
        var sysAdminRole = usersContext.GetSysAdminRole();
        var siteAdminRole = usersContext.GetSiteAdminRole();
        var userRole = usersContext.GetUserRole();
        var pilotRole = usersContext.GetPilotRole();

        var readPermission = usersContext.GetReadPermissions();
        var allPermission = usersContext.GetAllPermissions();
        var sitePermission = usersContext.GetSitePermissions();
        var consignmentPermission = usersContext.GetConsignmentPermissions();

        syncRole.SetPermissions(readPermission).And.SetWeight(0);
        sysAdminRole.SetPermissions(allPermission).And.SetWeight(5);
        siteAdminRole.SetPermissions(sitePermission).And.SetWeight(10);
        pilotRole.SetPermissions(consignmentPermission).And.SetWeight(14);
        userRole.SetPermissions(readPermission).And.SetWeight(15);

        usersContext.SaveChanges();

        Site syncSite = new() { Name = "SYNC_SETUP", IsDefault = true };
        var existingSite = settingsContext.GetNamedRecord<Site>(syncSite.Name);
        if (existingSite == null)
        {
            settingsContext.AddToDbSet(syncSite);
            settingsContext.SaveChanges();
        }

        
        if (settingsContext.GetNamedRecord<User>("sa") is null)
        {
            var language = settingsContext.GetNamedRecord<Language>("en");;
            Role role = settingsContext.GetNamedRecord<Role>(syncRole.Name!);

            settingsContext.AddToDbSet(new User()
            {
                Name = "sa",
                Roles = new[] { role },
                Languages = new[] { language },
                IsDefault = true
            });
            settingsContext.SaveChanges();
        }

    }
}
