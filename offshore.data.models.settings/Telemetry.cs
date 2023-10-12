using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

//[Table("tblTelData")]
public class Telemetry : OffshoreDataModel
{
    //[Column("TelDataID")]
    public uint Id { get; set; }

    //[Column("TelDataRef"), Required, MaxLength(10)]
    public string Name { get; set; } = VALUE_NOT_SET;

    //[Column("TelDataActive"), Required]
    public bool IsActive { get; set; } = false;

    //[Column("TelDataOnSPM"), MaxLength(10)]
    public virtual SinglePointMooring? Spm { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Telemetry>(e =>
        {
            e.HasKey(r => r.Id);
        });
    }
}
