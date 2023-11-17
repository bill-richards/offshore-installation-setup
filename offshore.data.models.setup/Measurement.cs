using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblMeasure")]
public class Measurement : OffshoreDataModel
{
    public string? Measure { get; set; }
    [Column("MUnitIDDefault")] public uint DefaultMeasurementUnit { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Measurement>(modelBuilder);
    }
}