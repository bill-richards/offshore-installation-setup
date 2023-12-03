using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Languages", Schema = "lang")]
public class Language : NamedOffshoreDataModel
{
    [Required] public string Display { get; set; } = "";

    public virtual ICollection<Translation> Translations { get; init; } = [];
    public ICollection<User> Users { get; init; } = [];

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Language>(modelBuilder);
        modelBuilder.Entity<Language>(e =>
        {
            e.HasMany(p => p.Translations);
        });
    }
}