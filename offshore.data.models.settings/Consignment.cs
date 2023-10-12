using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblConsignment")]
public class Consignment : OffshoreDataModel
{
    //    [Column("ConsignmentId"), Required]
    public uint Id { get; set; }

    public SinglePointMooring? Spm { get; set; }

    public string TankerName { get; set; } = VALUE_NOT_SET;

    public string TankerImo { get; set; } = VALUE_NOT_SET;

    public uint TankerLength { get; set; }

    public uint TankerBeam {  get; set; }

    //    [Column("ConStartDate")]
    public DateTime StartDate { get; set; }

    //    [Column("ConStopDate")]
    public DateTime EndDate { get; set; }

    public uint BowOffset { get; set; }

    public uint HeadOffset { get; set; }
    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consignment>(e =>
        {
            e.HasIndex(p => p.Id);
        });
    }
}