using Microsoft.EntityFrameworkCore;
using offshore.data;
using offshore.data.sqlite;

namespace example.data.models.contexts;

public class LibraryContext : OffshoreDbContext, ILibraryContext
{
    public LibraryContext(IOffshoreDbConfiguration databaseConfiguration, string path, string databaseType = "SqlExpress", bool create = true)
        : base(databaseConfiguration, databaseType, path, create) { }

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => DatabaseConfiguration.OnConfiguring(optionsBuilder, FilePath);
    
    public override int SaveChanges() => base.SaveChanges();

    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new Publisher().OnModelCreating(modelBuilder);
        new Book().OnModelCreating(modelBuilder);
    }

}
