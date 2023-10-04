using Microsoft.EntityFrameworkCore;
using offshore.data;

namespace example.data.models.contexts;

public interface ILibraryContext : IOffshoreDbContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Publisher> Publishers { get; set; }
}
