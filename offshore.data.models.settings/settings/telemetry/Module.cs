using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class Module : OffshoreDataModel
{

    [Required]
    public string? Name { get; set; }
    [Required]
    public uint GraphMinimum { get; set; }

    public virtual ICollection<Sensor>? Sensors { get; set; }
    public virtual ICollection<SinglePointMooring>? SinglePointMoorings { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Module>(modelBuilder);
        modelBuilder.Entity<Module>(e =>
        {
            e.HasAlternateKey(p => p.Name);
            e.HasMany(p => p.Sensors).WithOne(s => s.Module);
            e.HasMany(p => p.SinglePointMoorings).WithMany(spm => spm.Modules);
        });
    }
}
