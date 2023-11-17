using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblMUnit")]
public class MeasurementUnit : OffshoreDataModel
{
    [Column("MeasureID")] public uint MeasurementId { get; set; }

    [Column("MUnitDesc")] public string? Description { get; set; }
    [Column("MUnitLabel")] public string? Label { get; set; }
    [Column("MUnitFactor")] public double Factor { get; set; } = 1d;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<MeasurementUnit>(modelBuilder);
    }
}
