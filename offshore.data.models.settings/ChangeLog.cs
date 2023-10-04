using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("tblChangeLog")]
public class ChangeLog : OffshoreDataModel
{
    [Column("ChangeId"), Required]
    public uint Id { get; set; }

    [Column("ChangeDate"), Required]
    public DateTime? Date { get; set; }

    [Column("ChangeDoneBy"), Required, MaxLength(20)]
    public string User { get; set; } = VALUE_NOT_SET;

    [Column("Change"), Required, MaxLength(250)]
    public string Detail { get; set; } = VALUE_NOT_SET;

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChangeLog>(e =>
        {
            e.HasIndex(p => p.Id);
            e.HasIndex(p => p.Date);
        });
    }
}