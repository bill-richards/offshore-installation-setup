using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("TelemetryData")]
public class Telemetry : OffshoreDataModel
{
    [Required] public string? Name { get; set; }

    [Required] public bool IsActive { get; set; } = false;

    public virtual SinglePointMooring? Spm { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Telemetry>(modelBuilder);
        modelBuilder.Entity<Telemetry>(e =>
        {
            e.HasOne(p => p.Spm);
            e.HasAlternateKey(p => p.Name);
        });
    }
}
