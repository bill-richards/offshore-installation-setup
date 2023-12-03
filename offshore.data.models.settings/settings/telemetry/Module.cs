using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class Module : NamedOffshoreDataModel
{

    [Required]
    public uint GraphMinimum { get; set; }

    public virtual ICollection<SinglePointMooring> SinglePointMoorings { get; init; } = [];
    public virtual ICollection<ModuleSensor> Sensors { get; init; } = [];



    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Module>(modelBuilder);
        modelBuilder.Entity<Module>(e =>
        {
            e.HasMany(p => p.Sensors);
            e.HasMany(p => p.SinglePointMoorings).WithMany(spm => spm.Modules);
        });
    }
}
