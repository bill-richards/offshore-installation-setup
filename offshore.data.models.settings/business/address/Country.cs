using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Countries", Schema ="biz")]
public class Country : OffshoreDataModel
{
    [Required] public string Name { get; set; } = "";

    public ICollection<Address> Addresses { get; set; } = [];

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Country>(modelBuilder);
        modelBuilder.Entity<Country>(e =>
        {
            e.HasMany(p => p.Addresses).WithOne(a => a.Country);
        });
    }
}