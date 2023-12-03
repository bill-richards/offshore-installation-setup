using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings;

public static class UserExtensions
{
    public const string AllPermissionName = "super_powers";
    public const string ConsignmentPermissionName = "consignment_admin";
    public const string SitePermissionName = "site_admin";
    public const string ReadPermissionName = "read_only";

    public const string SyncRoleName = "Synchronisation";
    public const string SysAdminRoleName = "System Admin";
    public const string SiteAdminRoleName = "Site Admin";
    public const string PilotRoleName = "Pilot";
    public const string UserRoleName = "User";

    private const string PermissionErrorMessage = @"The permissions set {0} does not exist and the current context has unsaved changes.\nSave all tracked changes before calling this method.";
    private const string RoleErrorMessage = @"The {0} role does not exist and the current context has unsaved changes.\nSave all tracked changes before calling this method.";

    public static Permission GetAllPermissions(this IUserDataContext context)
    {
        var permission = context.GetNamedRecord<Permission>(AllPermissionName);
        if (permission == null)
        {
            var allPermissions = new Permission(AllPermissionName)
            {
                IsDefault = true
            };
            context.AddToDbSet(allPermissions);
            permission = context.GetDbSet<Permission>().Local.GetNamedRecord(AllPermissionName);
        }
        return permission;
    }

    public static Permission GetConsignmentPermissions(this IUserDataContext context)
    {
        var permission = context.GetNamedRecord<Permission>(ConsignmentPermissionName);
        if (permission == null)
        {
            permission = new Permission
            {
                Name = ConsignmentPermissionName,
                IsDefault = true
            };

            foreach (var property in permission.GetType().GetProperties().Where(p => p.Name.EndsWith("Consignment") && !p.Name.StartsWith("CanDelete")))
            {
                property.SetValue(permission, true);
            }

            context.AddToDbSet(permission);
            permission = context.GetDbSet<Permission>().Local.GetNamedRecord(ConsignmentPermissionName);
        }
        return permission;
    }

    public static Permission GetSitePermissions(this IUserDataContext context)
    {
        var permission = context.GetNamedRecord<Permission>(SitePermissionName);
        if (permission == null)
        {
            permission = new Permission
            {
                Name = SitePermissionName,
                CanDeleteConsignment = true,
                IsDefault = true
            };

            foreach (var property in permission.GetType().GetProperties().Where(p => p.Name is not ("Name" or "Roles" or "Id" or "CanCreateSite" or "CanAssignSysAdmin" or "IsDeleted")))
            {
                if (!property.Name.StartsWith("CanDelete"))
                {
                    property.SetValue(permission, true);
                }
            }

            context.AddToDbSet(permission);
            permission = context.GetDbSet<Permission>().Local.GetNamedRecord(SitePermissionName);
        }
        return permission;
    }

    public static Role SetPermissions(this Role role, Permission permission)
    {
        role.PermissionSet = permission;
        return role;
    }

    public static Permission GetReadPermissions(this IUserDataContext context)
        => GetRecordAndCreateIfMissing<Permission>(ref context, ReadPermissionName, PermissionErrorMessage);

    public static Role GetSyncRole(this IUserDataContext context)
        => GetRecordAndCreateIfMissing<Role>(ref context, SyncRoleName, RoleErrorMessage);

    public static Role GetSysAdminRole(this IUserDataContext context)
        => GetRecordAndCreateIfMissing<Role>(ref context, SysAdminRoleName, RoleErrorMessage);

    public static Role GetSiteAdminRole(this IUserDataContext context)
        => GetRecordAndCreateIfMissing<Role>(ref context, SiteAdminRoleName, RoleErrorMessage);

    public static Role GetPilotRole(this IUserDataContext context)
        => GetRecordAndCreateIfMissing<Role>(ref context, PilotRoleName, RoleErrorMessage);
    public static Role GetUserRole(this IUserDataContext context)
        => GetRecordAndCreateIfMissing<Role>(ref context, UserRoleName, RoleErrorMessage);

    private static TModelType GetRecordAndCreateIfMissing<TModelType>(ref IUserDataContext context, string namePropertyValue, string errorFormatString)
        where TModelType : OffshoreDataModel, new()
    {
        var record = context.GetNamedRecord<TModelType>(namePropertyValue);
        if (record == null)
        {
            //if (context.ChangeTracker.HasChanges())
            //    throw new InvalidOperationException(string.Format(errorFormatString, namePropertyValue));

            record = new TModelType();
            record.GetType().GetProperty("Name")!.SetValue(record, namePropertyValue);
            record.GetType().GetProperty("IsDefault")!.SetValue(record, true);
            context.AddToDbSet(record);
            //context.SaveChanges();

            record = context.GetDbSet<TModelType>().Local.GetNamedRecord(namePropertyValue);
        }
        return record;
    }
}
