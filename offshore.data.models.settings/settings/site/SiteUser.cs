using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("SiteUsers", Schema = "config")]
public class SiteUser : OffshoreDataModel
{
    public Site? Site { get; init; }
    public User? User { get; init; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<SiteUser>(modelBuilder);
        modelBuilder.Entity<SiteUser>(e =>
        {
            e.HasOne(p => p.User);
            e.HasOne(p => p.Site).WithMany(s => s.Users);
        });
    }
}
