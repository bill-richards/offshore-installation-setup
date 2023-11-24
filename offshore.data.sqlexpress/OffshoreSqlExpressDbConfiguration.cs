using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace offshore.data.sqlexpress;

public class OffshoreSqlExpressDbConfiguration : IOffshoreDbConfiguration, ISettingsSchema, IUsersSchema, ILanguageSchema, IBusinessSchema, IConfigurationSchema
{
    private string _connectionString;

    public string DatabaseType => "SqlExpress";
    public virtual string Schema { get; init; }

    public OffshoreSqlExpressDbConfiguration(string connectionString, string schema = "dbo")
    {
        _connectionString = connectionString;
        Schema = schema;
    }
    public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (string.IsNullOrWhiteSpace(_connectionString))
            throw new FieldAccessException("ConnectionString cannot be empty or whitespace");

        optionsBuilder.UseSqlServer(_connectionString, //); 
            o => o.MigrationsHistoryTable(tableName: HistoryRepository.DefaultTableName, schema: Schema).MigrationsAssembly("offshore.data.sqlexpress"));
    }

    public void SetConnectionString(string connectionString) => _connectionString = connectionString;
}
