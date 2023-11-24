using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

public class MeasurementType : OffshoreDataModel
{
    [Required]
    public string Name { get; set; } = "";

    [NotMapped] public string DefaultUnitRef { get; set; } = "";

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<MeasurementType>(modelBuilder);
        modelBuilder.Entity<MeasurementType>(e =>
        {
            e.HasAlternateKey(p => p.Name);
        });
    }
}
