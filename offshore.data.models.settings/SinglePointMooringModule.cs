using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblSpmModules")]
public class SinglePointMooringModule : OffshoreDataModel
{
    public uint Id { get; set; }

    public SinglePointMooringModule? Spm { get; set; }

    public Module? Module { get; set; }

    public Site? Site { get; set; }

    public bool Enabled { get; set; } = true; 


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SinglePointMooringModule>(e =>
        {
            e.HasKey(e => e.Id);
        });
    }
}