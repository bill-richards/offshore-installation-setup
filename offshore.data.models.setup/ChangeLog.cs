using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblChangeLog")]
public class ChangeLog : OffshoreDataModel
{
    [Column("ChangeDate")] public DateTime Date { get; set; } = DateTime.Now;
    [Column("ChangeDoneBy")] public uint UserId { get; set; }
    [Column("Change")] public string Detail { get; set; } = VALUE_NOT_SET;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<ChangeLog>(modelBuilder);
    }
}