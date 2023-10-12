using Microsoft.EntityFrameworkCore;

namespace offshore.data.sqlexpress;

public class OffshoreSqlExpressDbConfiguration : IOffshoreDbConfiguration
{
    public string DatabaseType => "SqlExpress";

    public void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string filePath)
    {
        optionsBuilder.UseSqlServer(filePath);
    }
}
