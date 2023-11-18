using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data.models.settings;

[Table("CountryCodes", Schema ="biz")]
public class CountryCode : OffshoreDataModel
{
    [Required] public string? DialingCode { get; set; }

    [Required] public Country? Country { get; set; }

    [NotMapped] public string? CountryRef {  get; set; }

    public ICollection<TelephoneNumber>? TelephoneNumbers { get; init; } = new HashSet<TelephoneNumber>();

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<CountryCode>(modelBuilder);
        modelBuilder.Entity<CountryCode>(e =>
        {
            e.HasOne(p => p.Country);
            e.HasMany(p => p.TelephoneNumbers).WithOne(t => t.CountryCode);
            e.HasIndex(new[]{ nameof(DialingCode), "CountryId" });
        });
    }
}