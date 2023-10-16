using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace offshore.data;

public interface IOffshoreDbContext : IDisposable
{
    string DatabaseType { get; }
    bool FreshDatabaseCreated { get; }

    void AddToDbSet<TModel>(TModel model) where TModel : class;
    void AddRangeToDbSet<TModel>(TModel[] models) where TModel : class;
    bool Contains<TModel>(TModel model) where TModel : class;

    TModel FirstOrDefault<TModel>(Func<TModel, bool> exp) where TModel : class;

    DbSet<TModel> GetDbSet<TModel>() where TModel : class;

    IOffshoreDbContext DeleteAllRecords<TModel>() where TModel : class;

    IOffshoreDbContext DeleteAllRecords<TModel>(IEnumerable<TModel> collection) where TModel : class;

    /* expose required members from DbContext through the interface */

    EntityEntry<TModel> Entry<TModel>(TModel model) where TModel : class;
    int SaveChanges();
}