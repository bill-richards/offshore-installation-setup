using Microsoft.EntityFrameworkCore;

namespace offshore.data;

public abstract class OffshoreDbContext : DbContext, IOffshoreDbContext
{
    public OffshoreDbContext(IOffshoreDbConfiguration databaseConfiguration, string databaseType, string path = "", bool create = true)
    {
        FilePath = path;
        DatabaseType = databaseType;
        DatabaseConfiguration = databaseConfiguration;
        if (create)
        {
            if (Database.EnsureCreated())
                FreshDatabaseCreated = true;
        }
    }

    public IOffshoreDbContext DeleteAllRecords<TModel>(IEnumerable<TModel> collection) where TModel : class
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        var set = property.GetValue(this, null) as DbSet<TModel>;
        set!.RemoveRange(collection);
        return this;
    }

    public IOffshoreDbContext DeleteAllRecords<TModel>() where TModel : class
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        var set = property.GetValue(this, null) as DbSet<TModel>;
        set!.RemoveRange(set);
        return this;
    }

    public bool Contains<TModel>(TModel model) where TModel : class
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        var set = property.GetValue(this, null) as DbSet<TModel>;
        return set!.Contains(model);
    }

    public void AddToDbSet<TModel>(TModel model) where TModel : class
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        var set = property.GetValue(this, null) as DbSet<TModel>;
        set!.Add(model);
    }

    public string FilePath { get; set; }
    protected IOffshoreDbConfiguration DatabaseConfiguration { get; }
    public bool FreshDatabaseCreated { get; }

    public string DatabaseType { get; }
}
