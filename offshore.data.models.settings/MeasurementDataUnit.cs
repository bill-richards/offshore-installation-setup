using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblMeasurementDataUnits")]
public class MeasurementDataUnit : OffshoreDataModel
{
    public uint Id { get; set; }
    public Measurement? Measurement { get; set; }
    public MeasurementUnit? MeasurementUnit { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeasurementDataUnit>(e =>
        {
            e.HasKey(p => p.Id);
        });
    }
}