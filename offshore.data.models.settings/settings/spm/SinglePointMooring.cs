using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class SinglePointMooring : OffshoreDataModel
{
    [Required] public Site? Site { get; set; }
    [Required]  public bool IsActive { get; set; } = true;
    [Required] public uint Index { get; set; }
    [Required] public string Name { get; set; } = "";
    [Required] public int CompassAdjustment { get; set; }
    [Required]  public int WindAdjustment { get; set; }
    [Required] public int AwacPosition { get; set; }
    [Required] public double GpsPlumLatitude { get; set; }
    [Required] public double GpsPlumLongitude { get; set; }
    [Required] public int GpsToUse { get; set; }
    [Required] public int GpsDistanceAdjustment { get; set; }
    [Required]  public int GpsBearingAdjustment { get; set; }
    [Required] public string Frequency { get; set; } = "";

    public virtual ICollection<Module> Modules { get; init; } = [];
    public virtual ICollection<LiveDatum> LiveData { get; init; } = [];


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<SinglePointMooring>(modelBuilder);
        modelBuilder.Entity<SinglePointMooring>(e =>
        {
            e.HasAlternateKey(p => p.Name);
            e.HasOne(p => p.Site).WithMany(r => r.SinglePointMoorings);
            e.HasMany(p => p.Modules);
        });
    }
}

