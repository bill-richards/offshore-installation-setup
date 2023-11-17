using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

public class Sensor : OffshoreDataModel
{
    [Required] public string? Name { get; set; }
    public string? SerialNumber { get; set; }
    [Required] public double MinimumValue { get; set; } = 0;
    [Required] public double? MaximumValue { get; set; }
    [Required] public uint DecimalPlaces { get; set; } = 0;
    [Required] public uint? AlarmInterval { get; set; }
    [Required, Column(TypeName = "nvarchar(8)")] public string? DataArrayPosition { get; set; }
    [Required] public bool IsActive { get; set; } = false;

    public virtual MeasurementType? Measurement { get; set; }
    public virtual MeasurementUnit? DefaultMeasurementUnit { get; set; }
    public virtual Calibration? Calibration { get; set; }
    public virtual Telemetry? Telemetry { get; set; }
    public virtual Module? Module { get; set; }

    public virtual ICollection<Alarm>? Alarms { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Sensor>(modelBuilder);
        modelBuilder.Entity<Sensor>(e =>
        {
            e.HasOne(p => p.Measurement);
            e.HasOne(p => p.DefaultMeasurementUnit);
            e.HasOne(p => p.Calibration);
            e.HasOne(p => p.Telemetry);
            //e.Property(p => p.DataArrayPosition)
            // .HasConversion(
            //    v => string.Join(",", v!),
            //    v => v!.Split(new[] { ',' }).Select(i => uint.Parse(i)).ToArray());
        });
    }
}
