using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class MeasurementUnit : OffshoreDataModel
{
    [Required]
    public string? Description { get; set; }
    [Required]
    public string? Label { get; set; }
    [Required]
    public double Factor { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<MeasurementUnit>(modelBuilder);
        modelBuilder.Entity<MeasurementUnit>(e =>
        {
            //e.HasAlternateKey(p => p.Description);
        });
    }
}
