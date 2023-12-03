using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace offshore.data;

public abstract class OffshoreDataModel
{
    public uint Id { get; set; }
    public bool IsDefault { get; set; } = false;
    [Required] public bool IsDeleted { get; set; } = false;

    public abstract void OnModelCreating(ModelBuilder modelBuilder);
    public void OnModelCreating<TModelType>(ModelBuilder modelBuilder) where TModelType : OffshoreDataModel
    {
        modelBuilder.Entity<TModelType>(e =>
        {
            e.HasKey("Id");
        });
    }
}

public abstract class NamedOffshoreDataModel : OffshoreDataModel
{
    [Required] public string Name { get; set; } = "";

    new public void OnModelCreating<TModelType>(ModelBuilder modelBuilder) where TModelType : NamedOffshoreDataModel
    {
        modelBuilder.Entity<TModelType>(e =>
        {
            base.OnModelCreating<TModelType>(modelBuilder);
            e.HasIndex("Name");
        });
    }
}
