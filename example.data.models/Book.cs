using Microsoft.EntityFrameworkCore;
using offshore.data;
using System.ComponentModel.DataAnnotations;

namespace example.data;

public class Book : OffshoreDataModel
{
    public string? ISBN { get; set; }

    [Required]
    public string Title { get; set; } = VALUE_NOT_SET;
    public string? Description { get; set; }
    public string? Author { get; set; }

    public string? Language { get; set; }
    public DateOnly PublicationDate { get; set; }

    public virtual Publisher? Publisher { get; set; }

    public override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.ISBN);
            entity.HasOne(d => d.Publisher).WithMany(p => p.Books);
            entity.HasIndex(e => e.ISBN);
            entity.HasIndex(e => e.Author);
        });
    }
}
