using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblReport")]
public class Report : OffshoreDataModel
{
    [Column("Report")] public string? Name { get; set; }
    [Column("ReportActive")] public bool IsActive { get; set; } = true;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Report>(modelBuilder);
    }
}
