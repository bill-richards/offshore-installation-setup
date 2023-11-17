using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Languages", Schema = "lang")]
public class Language : OffshoreDataModel
{
    [Required] public string? ShortName { get; set; }
    [Required] public string? Name { get; set; }

    public virtual ICollection<Translation>? Translations { get; set; }
    public ICollection<User>? Users { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Language>(modelBuilder);
        modelBuilder.Entity<Language>(e =>
        {
            //e.HasAlternateKey(p => p.Name);
            //e.HasAlternateKey(p => p.ShortName);
            e.HasMany(p => p.Translations);
        });
    }
}