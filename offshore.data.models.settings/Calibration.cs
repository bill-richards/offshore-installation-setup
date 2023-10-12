using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblCalibration")]
public class Calibration : OffshoreDataModel
{
    public uint Id { get; set; }

    //    [Column("SensorId"), Required]
    public Sensor? Sensor { get; set; }

    //[Column("TelRefArrayPos"), Required]
    public uint DataPosition { get; set; }

    //[Column("CalDate"), Required]
    public DateTime? Date { get; set; }

    //[Column("CalRAW"), Required]
    public uint Raw { get; set; }

    //    [Column("CalZero"), Required]
    public uint Zero { get; set; }

    //[Column("CalValue"), Required]
    public double Value { get; set; }

    //[Column("Cal"), Required]
    public double Data {  get; set; }

    //[Column("CalDoneBy"), Required]
    public string CalibratedBy { get; set; } = VALUE_NOT_SET;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calibration>(e =>
        {
            e.HasIndex(p => p.Id);
        });
    }
}