using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class ModuleSensor : OffshoreDataModel
{
    [Required] public Module? Module { get; set; }
    [Required] public Sensor? Sensor { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<ModuleSensor>(modelBuilder);
        modelBuilder.Entity<ModuleSensor>(e =>
        {
            e.HasOne(m => m.Sensor);
            e.HasOne(m => m.Module).WithMany(m => m.Sensors);
        });
    }
}
