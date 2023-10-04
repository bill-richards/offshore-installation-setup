using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblTranslations")]
public class Translation : OffshoreDataModel
{
    public uint Id { get; set; }

    public SupportedLanguage? Language { get; set; }

    public TranslatableString? TranslatableString { get; set; }

    public string Value { get; set; } = VALUE_NOT_SET;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translation>(e =>
        {
            e.HasIndex(p => p.Id);
            e.HasOne(p => p.Language).WithMany(e => e.Translations);
            e.HasOne(p => p.TranslatableString).WithMany(e => e.Translations);  
        });
    }
}