using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblMeasure")]
public class Measurement : OffshoreDataModel
{
    //    [Column("MeasureId"), Required]
    public uint Id { get; set; }

    //[Column("Measure")]
    public string Name { get; set; } = VALUE_NOT_SET;

    //[Column("MUnitIdDefault")]
    public MeasurementUnit? DefaultUnit { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Measurement>(e =>
        {
            e.HasIndex(p => p.Id);
        });
    }
}