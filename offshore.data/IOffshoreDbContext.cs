namespace offshore.data;

public interface IOffshoreDbContext : IDisposable
{
    string FilePath { get; set; }
    bool FreshDatabaseCreated { get; }

    void AddToDbSet<TModel>(TModel model) where TModel : class;
    bool Contains<TModel>(TModel model) where TModel : class;

    IOffshoreDbContext DeleteAllRecords<TModel>() where TModel : class;
    IOffshoreDbContext DeleteAllRecords<TModel>(IEnumerable<TModel> collection) where TModel : class;

    /* expose require members from DbContext through the interface */
    int SaveChanges();
}