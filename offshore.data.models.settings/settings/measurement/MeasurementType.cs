using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

public class MeasurementType : NamedOffshoreDataModel
{

    [NotMapped] public string DefaultUnitRef { get; set; } = "";

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<MeasurementType>(modelBuilder);
        modelBuilder.Entity<MeasurementType>(e =>
        {
        });
    }
}
