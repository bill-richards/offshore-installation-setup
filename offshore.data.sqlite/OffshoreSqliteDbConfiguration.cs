using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace offshore.data.sqlite;

public class OffshoreSqliteDbConfiguration : IOffshoreDbConfiguration
{
    private readonly string _filePath;
    public string DatabaseType => "Sqlite";

    public string Schema => throw new NotImplementedException();

    public OffshoreSqliteDbConfiguration(string filePath) {  _filePath = filePath; }

    public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (string.IsNullOrWhiteSpace(_filePath))
            throw new FieldAccessException("FilePath cannot be empty or whitespace");

        optionsBuilder.UseSqlite($"Data Source={_filePath}");
        raw.SetProvider(new SQLite3Provider_e_sqlite3());
    }
}
