using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblModule")]
public class Module : OffshoreDataModel
{
    public uint Id { get; set; }

    [Column("Module")]
    public string Name { get; set; } = VALUE_NOT_SET;

    [Column("ModGraphMin")]
    public uint GraphMinimum { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Module>(e =>
        {
            e.HasKey(e => e.Id);
        });
    }
}
