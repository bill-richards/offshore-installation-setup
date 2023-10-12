using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace offshore.data.sqlite;

public class OffshoreSqliteDbConfiguration : IOffshoreDbConfiguration
{
    public string DatabaseType => "Sqlite";

    public void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string filePath)
    {
        optionsBuilder.UseSqlite($"Data Source={filePath}");
        raw.SetProvider(new SQLite3Provider_e_sqlite3());
    }
}
