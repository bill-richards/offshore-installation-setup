using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblAlarms")]
public class Alarm : OffshoreDataModel
{
    [Column("AlarmID")]
    public uint Id { get; set; }

    [Column("SensorId"), Required]
    public Sensor? Sensor { get; set; }

    [Column("AlarmNeg"), Required]
    public bool AlarmBit { get; set; } = false;

    [Column("AlarmValue"), Required, MaxLength(18)]
    public double Threshold { get; set; }

    [Column("MUnitId"), Required]
    public MeasurementUnit? MeasurementUnit { get; set; }

    [Column("AlarmMessage"), Required]
    public string Message { get; set; } = VALUE_NOT_SET;

    [Column("AlarmColor"), Required]
    public uint DisplayColour { get; set; }

    [Column("AlarmSound"), Required]
    public bool RaiseSound { get; set; }

    [Column("AlarmSMS"), Required]
    public bool SendSms { get; set; }

    [Column("AlarmEmail"), Required]
    public bool SendEmail { get; set; }

    [Column("AlarmActive"), Required]
    public bool IsActive { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alarm>(entity =>
        {
            entity.HasIndex(r => r.Id);
        });
    }
}
