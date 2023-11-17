using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblModule")]
public class Module : OffshoreDataModel
{

    [Column("Module")] public string? Name { get; set; }
    [Column("ModSelect")] public bool Select { get; set; } = false;
    [Column("ModGraphMin")] public uint GraphMinimum { get; set; }
    [Column("ModOnSPM")] public string? SpmList { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Module>(modelBuilder);
    }
}
