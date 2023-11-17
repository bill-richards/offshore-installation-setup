using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblAlarm")]
public class Alarm : OffshoreDataModel
{
    public virtual uint SensorID { get; set; }
    public bool AlarmNeg { get; set; } = false;
    [Column("AlarmValue")] public double Value { get; set; }
    [Column("MUnitID")] public uint MeasurementUnit { get; set; }
    
    [Column("AlarmMessage")] public string? Message { get; set; };
    [Column("AlarmColour")] public uint DisplayColour { get; set; }
    [Column("AlarmSound")] public bool RaiseSound { get; set; } = false;
    [Column("AlarmSMS")] public bool SendSms { get; set; } = false;
    [Column("AlarmEmail")] public bool SendEmail { get; set; } = false;
    [Column("AlarmActive")] public bool IsActive { get; set; } = false;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Alarm>(modelBuilder);
    }
}

