using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace offshore.data;

public abstract class OffshoreDbContext : DbContext, IOffshoreDbContext
{
    public IOffshoreDbContext And => this;

    public LocalView<TModel> LocalView<TModel>() where TModel : OffshoreDataModel
        => GetDbSet<TModel>().Local!;

    public new EntityEntry<TModel> Entry<TModel>(TModel model) where TModel : OffshoreDataModel 
        => base.Entry(model);

    public OffshoreDbContext(IOffshoreDbConfiguration databaseConfiguration, string databaseType)
    {
        DatabaseType = databaseType;
        DatabaseConfiguration = databaseConfiguration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => DatabaseConfiguration.OnConfiguring(optionsBuilder);

    public IOffshoreDbContext DeleteAllRecords<TModel>(IEnumerable<TModel> collection) where TModel : OffshoreDataModel
    {
        GetDbSet<TModel>().RemoveRange(collection.Where(record => record.IsDefault == false));
        return this;
    }

    public IOffshoreDbContext DeleteAllRecords<TModel>() where TModel : OffshoreDataModel
    {
        var set = GetDbSet<TModel>();
        set?.RemoveRange(set.Where(record => record.IsDefault == false));
        return this;
    }

    public bool Contains<TModel>(TModel model) where TModel : OffshoreDataModel 
        => GetDbSet<TModel>().Contains(model);


    public TModel FirstOrDefault<TModel>(Func<TModel, bool> exp) where TModel : OffshoreDataModel 
        => GetDbSet<TModel>().FirstOrDefault(exp)!;


    public DbSet<TModel> GetDbSet<TModel>() where TModel : OffshoreDataModel
    {
        var property = GetType().GetProperties().First(p => p.GetValue(this, null) is DbSet<TModel>);
        return (property.GetValue(this, null) as DbSet<TModel>)!;
    }

    public IOffshoreDbContext AddToDbSet<TModel>(TModel model) where TModel : OffshoreDataModel
    {
        var set = GetDbSet<TModel>();
        var typeProperties = typeof(TModel).GetProperties().Where(p => !p.Name.Equals("Id"));
        var numberOfProperties = typeProperties.Count();
        var itemAlreadyExists = false;
        uint numberOfSameProperties = 0;

        foreach (var record in set!.AsEnumerable())
        {
            foreach (var property in typeProperties)
            {
                if (property.GetValue(record) == property.GetValue(model))
                    numberOfSameProperties += 1;
            }

            if (numberOfSameProperties == numberOfProperties)
            {
                itemAlreadyExists = true;
                continue;
            }
            numberOfSameProperties = 0;
        }

        if (!itemAlreadyExists)
            set!.Add(model);

        return this;
    }

    public IOffshoreDbContext AddRangeToDbSet<TModel>(TModel[] models) where TModel : OffshoreDataModel
    {
        GetDbSet<TModel>().AddRange(models);
        return this;
    }

    protected IOffshoreDbConfiguration DatabaseConfiguration { get; }

    public string DatabaseType { get; }

}
