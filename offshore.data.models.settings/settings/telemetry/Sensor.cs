using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class Sensor : NamedOffshoreDataModel
{
    [Required] public double MinimumValue { get; set; } = 0;
    [Required] public double MaximumValue { get; set; }
    [Required] public uint DecimalPlaces { get; set; } = 0;


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Sensor>(modelBuilder);
        modelBuilder.Entity<Sensor>(e =>
        {
        });
    }
}
