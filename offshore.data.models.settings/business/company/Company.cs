using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Companies", Schema ="biz")]
public class Company : OffshoreDataModel
{
    [Required] public string Name { get; set; } = "";

    [Required] public Location? Location { get; set; }

    public virtual ICollection<Site>? Sites { get; init; } = [];

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Company>(modelBuilder);
        modelBuilder.Entity<Company>(e =>
        {
            e.HasMany(p => p.Sites).WithOne(s => s.Company);
            e.HasOne(e => e.Location);
        });
    }
}
