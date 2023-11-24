using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace offshore.data;

public interface IOffshoreDbContext : IDisposable
{
    string DatabaseType { get; }

    IOffshoreDbContext And { get; }

    LocalView<TModel> LocalView<TModel>() where TModel : OffshoreDataModel;

    IOffshoreDbContext AddToDbSet<TModel>(TModel model) where TModel : OffshoreDataModel;
    IOffshoreDbContext AddRangeToDbSet<TModel>(TModel[] models) where TModel : OffshoreDataModel;
    bool Contains<TModel>(TModel model) where TModel : OffshoreDataModel;

    TModel FirstOrDefault<TModel>(Func<TModel, bool> exp) where TModel : OffshoreDataModel;

    DbSet<TModel> GetDbSet<TModel>() where TModel : OffshoreDataModel;

    IOffshoreDbContext DeleteAllRecords<TModel>() where TModel : OffshoreDataModel;

    IOffshoreDbContext DeleteAllRecords<TModel>(IEnumerable<TModel> collection) where TModel : OffshoreDataModel;

    /* expose required members from DbContext through the interface */

    ChangeTracker ChangeTracker { get; }
    DatabaseFacade Database { get; }

    EntityEntry<TModel> Entry<TModel>(TModel model) where TModel : OffshoreDataModel;
    int SaveChanges();
}