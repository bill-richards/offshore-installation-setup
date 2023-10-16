using Microsoft.EntityFrameworkCore;

namespace offshore.data;

public abstract class OffshoreDbContext : DbContext, IOffshoreDbContext
{
    public OffshoreDbContext(IOffshoreDbConfiguration databaseConfiguration, string databaseType, bool create = true)
    {
        DatabaseType = databaseType;
        DatabaseConfiguration = databaseConfiguration;
        if (create)
        {
            if (Database.EnsureCreated())
                FreshDatabaseCreated = true;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => DatabaseConfiguration.OnConfiguring(optionsBuilder);


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

    public TModel FirstOrDefault<TModel>(Func<TModel, bool> exp) where TModel : class
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        var set = property.GetValue(this, null) as DbSet<TModel>;
        return set!.FirstOrDefault(exp)!;
    }


    public DbSet<TModel> GetDbSet<TModel>() where TModel : class
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        return (property.GetValue(this, null) as DbSet<TModel>)!;
    }

    public void AddToDbSet<TModel>(TModel model) where TModel : class
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        var set = property.GetValue(this, null) as DbSet<TModel>;
        set!.Add(model);
    }

    public void AddRangeToDbSet<TModel>(TModel[] models) where TModel : class
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        var set = property.GetValue(this, null) as DbSet<TModel>;
        set!.AddRange(models);
    }

    protected IOffshoreDbConfiguration DatabaseConfiguration { get; }
    public bool FreshDatabaseCreated { get; }

    public string DatabaseType { get; }

}
