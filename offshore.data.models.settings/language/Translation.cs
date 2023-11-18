using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Translations", Schema = "lang")]
public class Translation : OffshoreDataModel
{
    public virtual Language? Language { get; set; }
    public virtual Translatable? Translatable { get; set; }

    [Required]
    public string? Value { get; set; }
    [NotMapped] public string? LanguageRef { get; set; }
    [NotMapped] public string? TranslatableRef { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Translation>(modelBuilder);
        modelBuilder.Entity<Translation>(e =>
        {
            e.HasOne(p => p.Language).WithMany(l => l.Translations);
            e.HasOne(p => p.Translatable).WithMany(t => t.Translations);
            e.HasAlternateKey(["LanguageId", "TranslatableId"]);
        });
    }
}