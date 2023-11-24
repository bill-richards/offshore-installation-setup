using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace offshore.data;

public abstract class OffshoreDataModel
{
    public uint Id { get; set; }
    public bool IsDefault { get; set; } = false;
    [Required] public bool IsDeleted { get; set; } = false;

    public abstract void OnModelCreating(ModelBuilder modelBuilder);
    public void OnModelCreating<TModelType>(ModelBuilder modelBuilder) where TModelType : class
    {
        modelBuilder.Entity<TModelType>(e =>
        {
            e.HasKey("Id");
        });
    }
}
