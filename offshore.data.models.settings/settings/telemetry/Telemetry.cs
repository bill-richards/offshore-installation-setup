using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("TelemetryData")]
public class Telemetry : NamedOffshoreDataModel
{
    [Required] public bool IsActive { get; set; } = false;


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Telemetry>(modelBuilder);
        modelBuilder.Entity<Telemetry>(e =>
        {
        });
    }
}
