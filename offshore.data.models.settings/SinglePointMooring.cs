using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblSPM")]
public class SinglePointMooring : OffshoreDataModel
{
    [Column("SPMID")]
    public uint Id { get; set; }

    public Site? Site { get; set; }

    [Column("Active"), Required]
    public bool IsActive { get; set; } = true;

    [Column("SPMNo"), Required]
    public uint Index { get; set; }

    [Column("SPMReference"), Required]
    public string Name { get; set; } = VALUE_NOT_SET;

    public virtual ICollection<Module>? Modules { get; set; }
    public virtual ICollection<Sensor>? Sensors { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SinglePointMooring>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasOne(e => e.Site).WithMany(r => r.SinglePointMoorings);
            e.HasMany(e => e.Modules); //.WithOne(r => r.SinglePointMooring);
        });
    }
}

