using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Translatables", Schema = "lang")]

public class Translatable : NamedOffshoreDataModel
{
    public virtual ICollection<Translation> Translations { get; init; } = [];

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Translatable>(modelBuilder);
        modelBuilder.Entity<Translatable>(e =>
        {
            e.HasMany(p => p.Translations);
        });
    }
}
