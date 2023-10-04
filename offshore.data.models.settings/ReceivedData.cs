using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblRecData")]
public class ReceivedData : OffshoreDataModel
{
    [Column("RecDataID")]
    public uint Id { get; set; }

    [Column("RecDataDate"), Required]
    public DateTime Date { get; set; }

    [Column("RecDataSPMID"), Required]
    public SinglePointMooring? Spm { get; set; }

    [Column("RecDataRef"), Required]
    public Telemetry? TelemetryData { get; set; }

    [Column("RecDataRaw"), Required, MaxLength(2000)]
    public string RawData { get; set; } = VALUE_NOT_SET;

    [Column("RecDataProc"), MaxLength(300)]
    public string ProcessedData { get; set; } = VALUE_NOT_SET;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReceivedData>(e =>
        {
            e.HasIndex(r => r.Date);
        });
    }
}
