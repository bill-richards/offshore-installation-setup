using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Contacts", Schema = "biz")]
public class Contact : OffshoreDataModel
{
    [Required] public string? Name { get; set; }
    public string? JobTitle { get; set; }

    public TelephoneNumber? TelephoneNumber { get; set; }

    public ICollection<Location>? Locations { get; set; }


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Contact>(modelBuilder);
        modelBuilder.Entity<Contact>(e =>
        {
            e.HasMany(e => e.Locations).WithMany(e => e.Contacts);
            e.HasOne(e => e.TelephoneNumber);
        });
    }
}