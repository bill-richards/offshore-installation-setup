using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblSupportedLanguages")]
public class SupportedLanguage : OffshoreDataModel
{
    public string? ShortName { get; set; }
    public string? Name { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupportedLanguage>(e =>
        {
            e.Property<uint>("Id");
            e.HasIndex("Id");
            e.Property(p => p.Name).IsRequired();
            e.Property(p => p.ShortName).IsRequired();
        });
    }
}