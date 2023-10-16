using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace offshore.data.mongodb;


public class OffshoreMongoDbConfiguration : IOffshoreDbConfiguration
{
    private IMongoDatabase _database;
    public string DatabaseType => "MongoDb";

    public OffshoreMongoDbConfiguration(IMongoDatabase database) => _database = database;

    public void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (_database is null) 
            throw new FieldAccessException("IMongoDatabase cannot be null");

        optionsBuilder.UseMongoDB(_database.Client, _database.DatabaseNamespace.DatabaseName);
    }

}
