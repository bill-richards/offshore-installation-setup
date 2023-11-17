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

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Module>(modelBuilder);
        modelBuilder.Entity<Module>(e =>
        {
            e.HasAlternateKey(p => p.Name);
            e.HasMany(p => p.Sensors).WithOne(s => s.Module);
        });
    }
}

public class ModuleSensor : OffshoreDataModel
{
    public virtual Module? Module { get; set; }
    public virtual Sensor? Sensor { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<ModuleSensor>(modelBuilder);
        modelBuilder.Entity<ModuleSensor>(e =>
        {
            e.HasOne(p => p.Sensor);
            e.HasOne(p => p.Module);
        });
    }
}
