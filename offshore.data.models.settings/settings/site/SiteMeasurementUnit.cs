using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class SiteMeasurementUnit : OffshoreDataModel
{
    [Required] public virtual Site? Site { get; set; }
    [Required] public virtual MeasurementType? Measurement { get; set; }
    [Required] public virtual MeasurementUnit? Units { get; set; }
    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<SiteMeasurementUnit>(modelBuilder);
        modelBuilder.Entity<SiteMeasurementUnit>(e =>
        {
            e.HasOne(p => p.Site).WithMany(s => s.SiteMeasurementUnits);
            e.HasOne(p => p.Measurement);
            e.HasOne(p => p.Units);
        });
    }
}