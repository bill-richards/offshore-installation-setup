using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblLiveData")]
public class LiveDatum : OffshoreDataModel
{
    [Column("LiveDataID")]
    public uint Id { get; set; }

    [Column("LiveDataDate")]
    public DateTime Date { get; set; }

    [Column("LiveDataSPMID"), Required]
    public SinglePointMooring? Spm { get; set; }

    [Column("LiveDataRef"), Required]
    public Telemetry? TelemetryData { get; set; }

    [Column("LiveDataProc"), MaxLength(300)]
    public string Processed { get; set; } = VALUE_NOT_SET;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LiveDatum>(e =>
        {
            e.HasIndex(r => r.Date);

        });
    }
}

public class SinglePointMooringConfigurationForLiveData : IEntityTypeConfiguration<SinglePointMooring>
{
    public void Configure(EntityTypeBuilder<SinglePointMooring> builder)
    {
        builder.Property(p => p.Id).HasColumnName("LiveDataSPMID");
    }
}