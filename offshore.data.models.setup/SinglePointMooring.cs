using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblSPM")]
public class SinglePointMooring : OffshoreDataModel
{
    [Column("Active")] public bool IsActive { get; set; } = true;
    [Column("SPMNo")] public uint Index { get; set; }
    [Column("SPMReference")] public string? Name { get; set; }
    [Column("CompassAdj")] public int CompassAdjustment { get; set; }
    [Column("WindAdj")] public int WindAdjustment { get; set; }
    [Column("AWACPos")] public int AwacPosition { get; set; }
    [Column("GPSPlumLat")] public double GpsPlumLatitude { get; set; }
    [Column("GPSPlumLong")] public double GpsPlumLongitude { get; set; }
    public string? GpsToUse { get; set; }
    [Column("GPSDistAdj")] public int GpsDistanceAdjustment { get; set; }
    [Column("GPSBearAdj")] public int GpsBearingAdjustment { get; set; }
    [Column("SPMFrequency")] public string? Frequency { get; set; }
    public bool IsSpm { get; set; } = true;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<SinglePointMooring>(modelBuilder);
    }
}