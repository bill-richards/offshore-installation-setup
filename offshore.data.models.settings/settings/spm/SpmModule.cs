using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings;

public class SpmModule : OffshoreDataModel
{
    public SinglePointMooring? Spm { get; set; }


    public Module? Module { get; set; }

    public Site? Site { get; set; }

    public bool Enabled { get; set; } = true;


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<SpmModule>(modelBuilder);
        modelBuilder.Entity<SpmModule>(e =>
        {
            e.HasOne(p => p.Spm);
            e.HasOne(p => p.Site);
            e.HasOne(p => p.Module);
            e.HasKey(new[] { "SpmId", "ModuleId", "SiteId" });
        });
    }
}