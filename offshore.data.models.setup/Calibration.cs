using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblCalibration")]
public class Calibration : OffshoreDataModel
{
    [Column("CalDoneBy")] public string? CalibratedById { get; set; }
    public uint SensorId { get; set; }
    [Column("TelRefArrayPos")] public uint DataPosition { get; set; }
    [Column("CalDate")] public DateTime Date { get; set; } = DateTime.Now;
    [Column("CalRAW")] public uint Raw { get; set; }
    [Column("CalZero")] public uint Zero { get; set; }
    [Column("CalValue")] public double Value { get; set; }
    [Column("Cal")] public double Data { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Calibration>(modelBuilder);
    }
}