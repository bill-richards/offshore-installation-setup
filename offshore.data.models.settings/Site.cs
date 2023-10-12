using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblSite")]
public class Site : OffshoreDataModel
{
    //    [Column("SiteId"), Required]
    public uint Id { get; set; }

    public string Name { get; set; } = VALUE_NOT_SET;

    public virtual ICollection<SinglePointMooring>? SinglePointMoorings { get; set; }
    public virtual ICollection<Module>? Modules { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Site>(e =>
        {
            e.HasIndex(p => p.Id);
            e.HasMany(p => p.SinglePointMoorings).WithOne(r=>r.Site);
        });
    }
}