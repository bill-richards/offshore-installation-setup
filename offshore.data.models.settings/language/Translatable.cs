using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Translatables", Schema = "lang")]

public class Translatable : OffshoreDataModel
{
    [Required]
    public string Name { get; set; } = "";

    public virtual ICollection<Translation> Translations { get; init; } = [];

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Translatable>(modelBuilder);
        modelBuilder.Entity<Translatable>(e =>
        {
            e.HasIndex(p => p.Name).IsUnique();
            e.HasMany(p => p.Translations);
        });
    }
}
