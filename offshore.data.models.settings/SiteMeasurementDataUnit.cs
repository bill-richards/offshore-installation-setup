using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblSiteMeasurementDataUnits")]
public class SiteMeasurementDataUnit : OffshoreDataModel
{
    public uint Id { get; set; }
    public MeasurementDataUnit? MeasurementDataUnits { get; set; }
    public Site? Site{ get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SiteMeasurementDataUnit>(e =>
        {
            e.HasIndex(p => p.Id);
        });
    }
}