using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblTranslatableStrings")]
public class Translatable : OffshoreDataModel
{
    public string? Value { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Translatable>(e =>
        {
            e.Property<uint>("Id");
            e.HasIndex("Id");
            e.Property(p => p.Value).IsRequired();
        });
    }
}
