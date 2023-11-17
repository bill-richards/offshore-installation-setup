using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class ReceivedData : OffshoreDataModel
{
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;
    public virtual SinglePointMooring? Spm { get; set; }
    public virtual Telemetry? TelemetryData { get; set; }
    [Required]
    public string? RawData { get; set; }
    public string? ProcessedData { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<ReceivedData>(modelBuilder);
        modelBuilder.Entity<ReceivedData>(e =>
        {
            e.HasOne(p => p.Spm);
            e.HasOne(p => p.TelemetryData);
        });
    }
}
