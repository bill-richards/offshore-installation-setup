using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblConsignment")]
public class Consignment : OffshoreDataModel
{
    [Column("SPMID")] public uint Spm { get; set; }
    public string? TankerName { get; set; }
    public string? TankerImo { get; set; }
    public uint TankerLength { get; set; }
    public uint TankerBeam {  get; set; }
    [Column("ConStartDate")] public DateTime StartDate { get; set; }
    [Column("ConStopDate")] public DateTime EndDate { get; set; }
    public uint BowOffset { get; set; }
    public uint HeadOffset { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Consignment>(modelBuilder);
    }
}
