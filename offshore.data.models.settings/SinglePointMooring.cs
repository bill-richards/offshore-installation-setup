using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblSPM")]
public class SinglePointMooring : OffshoreDataModel
{
    //    [Column("SPMID")]
    public uint Id { get; set; }

    public Site? Site { get; set; }

    //[Column("Active"), Required]
    public bool IsActive { get; set; } = true;

    //[Column("SPMNo"), Required]
    public uint Index { get; set; }

    //[Column("SPMReference"), Required]
    public string Name { get; set; } = VALUE_NOT_SET;

    //[Column("CompassAdj")]
    public int? CompassAdjustment { get; set; }

    //[Column("WindAdj")]
    public int? WindAdjustment { get; set; }

    //[Column("AWCPos")]
    public int? AwacPosition { get; set; }

    //[Column("GPSPlumLat")]
    public double? GpsPlumLattitude { get; set; }

    //[Column("GPSPlumLong")]
    public double? GpsPlumLongitude { get; set; }

    public int? GpsToUse { get; set; }

    //[Column("GPSDistAdj")]
    public int? GpsDistanceAdjustment { get; set; }

    //[Column("GPSBearAdj")]
    public int? GpsBearingAdjustment { get; set; }

    //[Column("SPMFrequency"), MaxLength(50)]
    public string? Frequency { get; set; }


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SinglePointMooring>(e =>
        {
            e.HasKey(e => e.Id);
            e.HasOne(e => e.Site).WithMany(r => r.SinglePointMoorings);
        });
    }
}

