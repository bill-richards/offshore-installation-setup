using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class MeasurementType : OffshoreDataModel
{
    [Required]
    public string? Name { get; set; }
    public virtual MeasurementUnit? DefaultUnit { get; set; }


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<MeasurementType>(modelBuilder);
        modelBuilder.Entity<MeasurementType>(e =>
        {
            e.HasOne(p => p.DefaultUnit);
            e.HasAlternateKey(p => p.Name);
        });
    }
}
