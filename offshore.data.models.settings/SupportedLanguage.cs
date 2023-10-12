using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblSupportedLanguages")]
public class SupportedLanguage : OffshoreDataModel
{
    public string? Id { get; set; }

    public string Language { get; set; } = VALUE_NOT_SET;

    public virtual ICollection<Translation>? Translations { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupportedLanguage>(e =>
        {
            e.HasIndex(p => p.Id);
        });
    }
}