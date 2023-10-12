using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblSensor")]
public class Sensor : OffshoreDataModel
{
    public uint Id { get; set; }


    //    [Column("TelDataRef")]
    public Telemetry? Telemetry { get; set; }


    //    [Column("TelRefArrayPos")]
    public uint DataArrayPosition { get; set; }

    //[Column("Sensor"), MaxLength(150)]
    public string Name { get; set; } = VALUE_NOT_SET;

    //[Column("SensorSerialNo"), MaxLength(50)]
    public string SerialNumber { get; set; } = VALUE_NOT_SET;

    //[Column("SensorMin"), MaxLength(18)]
    public double MinimumValue { get; set; }

    //[Column("SensorMax"), MaxLength(18)]
    public double MaximumValue { get; set; }

    //[Column("SensorValDecPlace")]
    public uint DecimalPlaces { get; set; } = 0;

    //[Column("MeasureId")]
    public Measurement? Measurement { get; set; }

    //[Column("SensorDefaultMUnitId")]
    public MeasurementUnit? DefaultMeasurementUnit { get; set; }

    //[Column("SensorAlarmInterval")]
    public uint AlarmInterval { get; set; }

    //[Column("SensorActive")]
    public bool IsActive { get; set; } = false;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sensor>(e =>
        {
            e.HasKey(e => e.Id);
        });
    }
}
