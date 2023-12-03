using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace offshore.data.models.settings;

public static class RecordExtensions
{

    public static TModelType GetNamedRecord<TModelType>(this LocalView<TModelType> context, string name)
    where TModelType : OffshoreDataModel, new()
    {
        try
        {
            return context.FirstOrDefault(r => r.GetType().GetProperty("Name")!.GetValue(r)!.Equals(name))!;
        }
        catch (InvalidOperationException)
        {
            return null!;
        }
    }


    public static TModelType GetNamedRecord<TModelType>(this IOffshoreDbContext context, string name)
    where TModelType : OffshoreDataModel, new()
    {
        try
        {
            return context.FirstOrDefault<TModelType>(r => r.GetType().GetProperty("Name")!.GetValue(r)!.Equals(name));
        }
        catch (InvalidOperationException)
        {
            return null!;
        }
    }

    public static TModelType? GetNamedRecord<TModelType>(this DbSet<TModelType> set, string name)
    where TModelType : OffshoreDataModel, new()
    {
        try
        {
            return set.FirstOrDefault(r => r.GetType().GetProperty("Name")!.GetValue(r)!.Equals(name));
        }
        catch (InvalidOperationException)
        {
            return null!;
        }
    }

    public static TModelType GetNamedRecordWithNavigationProperties<TModelType>(this IOffshoreDbContext context, string name)
    where TModelType : OffshoreDataModel, new()
    {
        try
        {
            TModelType record = context.FirstOrDefault<TModelType>(r => r.GetType().GetProperty("Name")!.GetValue(r)!.Equals(name));
            context.Entry(record).Navigations.Load();
            return record;
        }
        catch (InvalidOperationException)
        {
            return null!;
        }
    }

    public static void Load(this IEnumerable<ReferenceEntry> collection)
    {
        foreach (var entry in collection) { entry.Load(); }
    }
    public static void Load(this IEnumerable<CollectionEntry> collection)
    {
        foreach (var entry in collection) { entry.Load(); }
    }
    public static void Load(this IEnumerable<NavigationEntry> collection)
    {
        foreach (var entry in collection) { entry.Load(); }
    }

    public static TModel FirstOrDefaultWithNavigationProperty<TModel>(this IOffshoreDbContext context, string propertyName, Func<TModel, bool> exp) where TModel : OffshoreDataModel
    {
        var set = context.GetDbSet<TModel>().ToList();
        foreach (var record in set)
        {
            context.Entry(record).Navigation(propertyName)?.Load();
        };

        return context.FirstOrDefault(exp);
    }

    public static TModel FirstOrDefaultWithNavigationProperties<TModel>(this IOffshoreDbContext context, Func<TModel, bool> exp) where TModel : OffshoreDataModel
    {
        foreach (var record in context.GetDbSet<TModel>())
        {
            context.Entry(record).Navigations.Load();
        };

        return context.FirstOrDefault(exp);
    }
}
