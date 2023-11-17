using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class Alarm : OffshoreDataModel
{
    public virtual Sensor? Sensor { get; set; }
    [Required]
    public bool AlarmBit { get; set; } = false;
    [Required]
    public double Threshold { get; set; }
    public virtual MeasurementUnit? MeasurementUnit { get; set; }
    [Required]
    public string? Message { get; set; }
    [Required]
    public uint DisplayColour { get; set; }
    [Required]
    public bool RaiseSound { get; set; } = false;
    [Required]
    public bool SendSms { get; set; } = false;
    [Required]
    public bool SendEmail { get; set; } = false;
    [Required]
    public bool IsActive { get; set; } = false;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Alarm>(modelBuilder);
        modelBuilder.Entity<Alarm>(e =>
        {
            e.HasOne(p => p.Sensor).WithMany(s => s.Alarms).IsRequired();
        });
    }
}
