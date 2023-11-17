using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class ChangeLog : OffshoreDataModel
{
    public DateTime Date { get; set; } = DateTime.Now;
    [Required]
    public User? User { get; set; }
    public Site? Site { get; set; }
    [Required]
    public string? Detail { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<ChangeLog>(modelBuilder);
        modelBuilder.Entity<ChangeLog>(e =>
        {
            e.HasIndex(p => p.Date);
            e.HasOne(p => p.User);
            e.HasOne(p => p.Site);
        });
    }
}