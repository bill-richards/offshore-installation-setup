using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblTelData")]
public class TelemetryData : OffshoreDataModel
{
    [Column("TelDataRef")] public string? Name { get; set; }
    [Column("TelDataActive")] public bool IsActive { get; set; } = true;
    [Column("TelDataOnSPM")] public uint[]? SpmList { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<TelemetryData>(modelBuilder);
        modelBuilder.Entity<TelemetryData>(e =>
        {
            e.Property(p => p.SpmList)
             .HasConversion(
                v => string.Join(",", v!),
                v => v!.Split(new[] { ',' }).Select(i => uint.Parse(i)).ToArray());
        });
    }
}

