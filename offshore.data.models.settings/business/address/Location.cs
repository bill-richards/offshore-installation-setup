using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Locations", Schema ="biz")]
public class Location : NamedOffshoreDataModel
{
    [Required] public virtual Address? Address { get; set; }

    public virtual ICollection<Contact> Contacts { get; init; } = [];

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Location>(modelBuilder);
        modelBuilder.Entity<Location>(e =>
        {
            e.HasOne(e => e.Address);
            e.HasMany(e => e.Contacts).WithMany(c => c.Locations);
        });
    }
}