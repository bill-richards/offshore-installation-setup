using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("TelephoneNumbers", Schema ="biz")]
public class TelephoneNumber : OffshoreDataModel
{
    [Required] public TelephoneType? Type { get; set; }
    [Required] public CountryCode? CountryCode { get; set; }
    [Required] public ulong Number { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<TelephoneNumber>(modelBuilder);
        modelBuilder.Entity<TelephoneNumber>(e =>
        {
            e.HasMany(p => p.Users).WithMany(p => p.TelephoneNumbers);
            e.HasOne(p => p.Type);
            e.HasOne(p => p.CountryCode).WithMany(c => c.TelephoneNumbers);
            e.HasIndex(new[] { nameof(Number) });
        });
    }
}