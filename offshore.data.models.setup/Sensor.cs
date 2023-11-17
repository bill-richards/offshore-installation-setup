using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblSensor")]
public class Sensor : OffshoreDataModel
{
    [Column("TelDataRef")] public string? TelemetryDataReference { get; set; }
    [Column("Sensor")] public string? Name { get; set; }
    [Column("SensorSerialNo")] public string? SerialNumber { get; set; }
    [Column("SensorMin")] public double MinimumValue { get; set; } = 0;
    [Column("SensorMax")] public double? MaximumValue { get; set; }
    [Column("SensorValDecPlace")] public uint DecimalPlaces { get; set; } = 0;
    [Column("SensorAlarmInterval")] public uint? AlarmInterval { get; set; }
    [Column("TelRefArrayPosition", TypeName = "nvarchar(10)")] 
    public uint[]? DataArrayPosition { get; set; }
    [Column("SensorActive")] public bool IsActive { get; set; } = false;

    [Column("MeasureID")] public uint MeasurementId { get; set; }
    [Column("SensorDefaultMUnitID")] public uint DefaultMeasurementUnitId { get; set; }
    [Column("SPMNo")] public uint SpmNumber { get; set; }
    public uint ModuleId { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Sensor>(modelBuilder);
        modelBuilder.Entity<Sensor>(e =>
        {
            e.Property(p => p.DataArrayPosition)
             .HasConversion(
                v => string.Join(",", v!),
                v => v!.Split(new[] { ',' }).Select(i => uint.Parse(i)).ToArray());
        });
    }
}
