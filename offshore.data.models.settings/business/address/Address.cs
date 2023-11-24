using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("Addresses", Schema ="biz")]
public class Address : OffshoreDataModel
{
    [Required] public string Line1 { get; set; } = "";
    public string Line2 { get; set; } = "";
    [Required] public string City { get; set; } = "";
    public string County { get; set; } = "";
    public string State { get; set; } = "";
    public string Province { get; set; } = "";
    [Required] public Country? Country { get; set; }
    [Required] public string PostCode { get; set; } = "";

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<Address>(modelBuilder);
        modelBuilder.Entity<Address>(e =>
        {
            e.HasOne(p => p.Country).WithMany(c => c.Addresses);
        });
    }
}