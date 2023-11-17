using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblProfileMUnits")]
public class ProfileMeasurementUnits : OffshoreDataModel
{
    public uint ProfileId { get; set; }
    [Column("MeasureID")] public uint MeasurementId { get; set; }
    [Column("MUnitID")] public uint MeasurementUnitId { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<ProfileMeasurementUnits>(modelBuilder);
    }
}