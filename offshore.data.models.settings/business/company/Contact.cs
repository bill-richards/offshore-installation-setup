using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Contacts", Schema = "biz")]
public class Contact : NamedOffshoreDataModel
{
    public string JobTitle { get; set; } = "";

    public ICollection<TelephoneNumber> TelephoneNumbers { get; init; } = [];

    public ICollection<Location> Locations { get; init; } = [];


    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Contact>(modelBuilder);
        modelBuilder.Entity<Contact>(e =>
        {
            e.HasMany(e => e.Locations).WithMany(e => e.Contacts);
            e.HasMany(e => e.TelephoneNumbers).WithMany(t =>t.Contacts);
        });
    }
}