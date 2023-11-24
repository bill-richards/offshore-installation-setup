using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Permissions", Schema = "users")]
public class Permission : OffshoreDataModel
{
    public Permission() { }

    public Permission(string name)
    {
        Name = name;
        foreach (var property in GetType().GetProperties().Where(p => p.Name.StartsWith("Can")))
        {
            property.SetValue(this, true);
        }
    }

    [Required] public string? Name { get; set; }

    [Column("AssignSysAdmin")] public bool? CanAssignSysAdmin { get; set; } = false;

    [Column("CreateUser")] public bool? CanCreateUser { get; set; } = false;
    [Column("UpdateUser")] public bool? CanUpdateUser { get; set; } = false;
    [Column("DeleteUser")] public bool? CanDeleteUser { get; set; } = false;
    [Column("EnableUser")] public bool? CanEnableUser { get; set; } = false;

    [Column("CreateSite")] public bool? CanCreateSite { get; set; } = false;
    [Column("UpdateSite")] public bool? CanUpdateSite { get; set; } = false;
    [Column("DeleteSite")] public bool? CanDeleteSite { get; set; } = false;
    [Column("EnableSite")] public bool? CanEnableSite { get; set; } = false;

    [Column("CreateConsignment")] public bool? CanCreateConsignment { get; set; } = false;
    [Column("UpdateConsignment")] public bool? CanUpdateConsignment { get; set; } = false;
    [Column("DeleteConsignment")] public bool? CanDeleteConsignment { get; set; } = false;
    [Column("EnableConsignment")] public bool? CanEnableConsignment { get; set; } = false;

    [NotMapped] public virtual ICollection<Role> Roles { get; set; } = [];


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Permission>(modelBuilder);
        modelBuilder.Entity<Permission>(e =>
        {
            e.HasAlternateKey(p => p.Name);
            e.HasMany(p => p.Roles).WithOne(r => r.PermissionSet);
        });
    }
}
