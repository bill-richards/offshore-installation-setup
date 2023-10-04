using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblMUnit")]
public class MeasurementUnit : OffshoreDataModel
{
    [Column("MUnitId")]
    public uint Id { get; set; }

    [Column("MUnitDesc")]
    public string Description { get; set; } = VALUE_NOT_SET;

    [Column("MUnitLabel")]
    public string Label { get; set; } = VALUE_NOT_SET;


    [Column("MUnitFactor")]
    public double Factor { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeasurementUnit>(e =>
        {
            e.HasIndex(p => p.Id);
        });
    }
}

