//using Microsoft.EntityFrameworkCore;
//using MongoDB.Bson;
//using MongoDB.EntityFrameworkCore.Extensions;

//namespace offshore.data.models.settings.contexts;

//public interface ISettingsDataContext : IOffshoreDbContext
//{
//    public DbSet<Setting> Settings { get; set; }

//}

//public class SettingsDataContext : OffshoreDbContext, ISettingsDataContext
//{
//    public SettingsDataContext(IOffshoreDbConfiguration databaseConfiguration)
//        : base(databaseConfiguration, "MongoDb") { }

//    public DbSet<Setting> Settings { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        new Setting().OnModelCreating(modelBuilder);
//    }
//}

//public class Setting : OffshoreDataModel
//{
//    public ObjectId _id { get; set; }

//    public string? GivenName { get; set; }
//    public string? FamilyName { get; set; }

//    public override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Setting>(e =>
//        {
//            e.ToCollection("Settings");
//        });
//    }
//}