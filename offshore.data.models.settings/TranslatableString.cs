using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblTranslatableStrings")]
public class TranslatableString : OffshoreDataModel
{
    public uint Id { get; set; }

    public string String { get; set; } = VALUE_NOT_SET;

    public virtual ICollection<Translation>? Translations { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TranslatableString>(e =>
        {
            e.HasIndex(p => p.Id);
        });
    }
}