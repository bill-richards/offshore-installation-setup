using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.setup;

[Table("tblLang")]
public class Language : OffshoreDataModel
{
    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Language>(modelBuilder);
    }

    public string? English { get; set; }
    [Column("Espanol")] public string? Spanish { get; set;}
}