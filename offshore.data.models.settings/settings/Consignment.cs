using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data.models.settings;

public class Consignment : OffshoreDataModel
{
    [Required] public SinglePointMooring? Spm { get; set; }
    [Required] public string TankerName { get; set; } = "";
    [Required] public string TankerImo { get; set; } = "";
    [Required] public uint TankerLength { get; set; }
    [Required] public uint TankerBeam { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }
    [Required] public uint BowOffset { get; set; }
    [Required] public uint HeadOffset { get; set; }
    [Required] public bool IsEnabled { get; set; } = false;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Consignment>(modelBuilder);
        modelBuilder.Entity<Consignment>(e =>
        {
            e.HasOne(p => p.Spm);
        });
    }
}