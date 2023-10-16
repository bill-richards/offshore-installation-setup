using Microsoft.EntityFrameworkCore;

namespace offshore.data.sqlexpress;

public class OffshoreSqlExpressDbConfiguration : IOffshoreDbConfiguration
{
    private string _connectionString;
    
    public string DatabaseType => "SqlExpress";

    public OffshoreSqlExpressDbConfiguration(string connectionString) 
        => _connectionString = connectionString;

    public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
            throw new FieldAccessException("ConnectionString cannot be empty or whitespace");

        optionsBuilder.UseSqlServer(_connectionString);
    }

    public void SetConnectionString(string connectionString) => _connectionString = connectionString;
}
