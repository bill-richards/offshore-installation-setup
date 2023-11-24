using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class LiveDatum : OffshoreDataModel
{
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;
    [Required] public virtual Telemetry? TelemetryData { get; set; }
    public string Processed { get; set; } = "";

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<LiveDatum>(modelBuilder);
        modelBuilder.Entity<LiveDatum>(e =>
        {
            e.HasOne(p => p.TelemetryData);
        });
    }
}
