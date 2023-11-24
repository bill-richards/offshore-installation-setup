using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Sites", Schema = "config")]
public class Site : OffshoreDataModel
{
    [Required] public string Name { get; set; } = "";

    public Company? Company { get; set; }

    public Location? Location { get; set; }

    public virtual ICollection<SinglePointMooring> SinglePointMoorings { get; init; } = [];
    public virtual ICollection<SiteMeasurementUnit> SiteMeasurementUnits { get; init; } = [];
    public virtual ICollection<Calibration> Calibrations { get; init; } = [];

    public virtual ICollection<User> Users { get; init; } = [];

    public virtual SiteConfiguration? Configuration { get; set; }

    [Required] public bool IsEnabled { get; set; } = true;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Site>(modelBuilder);
        modelBuilder.Entity<Site>(e =>
        {
            e.HasOne(p => p.Company).WithMany(s => s.Sites);
            e.HasMany(p => p.SinglePointMoorings).WithOne(r => r.Site);
            e.HasMany(p => p.SiteMeasurementUnits);
            e.HasMany(p => p.Users);
            e.HasOne(p => p.Configuration);
            e.HasOne(p => p.Location);
        });
    }
}