using Microsoft.EntityFrameworkCore;

namespace offshore.data;

public interface IOffshoreDbConfiguration
{
    string DatabaseType { get; }
    void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
}
