using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

public class ModuleSensor : OffshoreDataModel
{
    [Required] public Module? Module { get; set; }
    [Required] public Sensor? Sensor { get; set; }
    public string SerialNumber { get; set; } = "";
    [Required, Column(TypeName = "nvarchar(8)")] public string DataArrayPosition { get; set; } = "";
    [Required] public Telemetry? Telemetry { get; set; }
    [Required] public MeasurementType? Measurement { get; set; }
    public Calibration? Calibration { get; init; }

    [Required] public bool IsActive { get; set; } = false;
    [NotMapped] public string TelemetryRef { get; set; } = "";

    public virtual ICollection<Alarm> Alarms { get; init; } = [];

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<ModuleSensor>(modelBuilder);
        modelBuilder.Entity<ModuleSensor>(e =>
        {
            e.HasOne(m => m.Sensor);
            e.HasOne(m => m.Module).WithMany(m => m.Sensors);
            e.HasOne(s => s.Telemetry);
            e.HasMany(s => s.Alarms);
            e.HasOne(s => s.Measurement);
            e.HasOne(s => s.Calibration);
        });
    }
}
