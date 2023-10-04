using Microsoft.EntityFrameworkCore;

namespace offshore.data;

public interface IOffshoreDbConfiguration
{
    void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string filePath = "");
}
