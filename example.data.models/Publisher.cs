using Microsoft.EntityFrameworkCore;
using offshore.data;

namespace example.data;

public class Publisher : OffshoreDataModel
{
    public string? Id { get; set; }
    public string? Name { get; set; }

    public virtual ICollection<Book>? Books { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired();
        });
    }
}
