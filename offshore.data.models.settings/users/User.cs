using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Users", Schema = "users")]
public class User : OffshoreDataModel
{
    [Required] public bool IsEnabled { get; set; } = true;
    [Required] public string? Name { get; set; }
    public string Email { get; set; } = "";
    public ICollection<Language> Languages { get; init; } = [];
    public ICollection<TelephoneNumber> TelephoneNumbers { get; init; } = [];

    [Required] public ICollection<Role> Roles { get; init; } = [];
    public ICollection<Site> Sites { get; init; } = [];


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<User>(modelBuilder);
        modelBuilder.Entity<User>(e =>
        {
            e.HasMany(p => p.Sites).WithMany(r => r.Users);
            e.HasMany(p => p.Roles).WithMany(r => r.Users);
            e.HasMany(p => p.Languages).WithMany(l => l.Users);
            e.HasMany(p => p.TelephoneNumbers).WithMany(t => t.Users);
            e.HasIndex(p => p.Name);
        });
    }
}
