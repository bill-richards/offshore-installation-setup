using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Roles", Schema = "users")]
public class Role : OffshoreDataModel
{
    [Required, Column("Type")]
    public string? Name { get; set; }

    public Permission? PermissionSet { get; set; }
    public ICollection<User>? Users { get; set; }
    public uint Weight { get; set; }

    [NotMapped] public Role And => this;

    public Role SetWeight(uint weight) {  Weight = weight;  return this; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Role>(modelBuilder);
        modelBuilder.Entity<Role>(e =>
        {
            e.HasMany(p => p.Users).WithMany(r => r.Roles);
            e.HasAlternateKey(p => p.Name);
            e.HasOne(p => p.PermissionSet).WithMany(p => p.Roles);
        });
    }
}
