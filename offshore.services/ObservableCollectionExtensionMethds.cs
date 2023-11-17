using System.Collections.ObjectModel;

namespace offshore.services;

public static class ObservableCollectionExtensionMethods
{
    public static void AddRange<TModel>(this ObservableCollection<TModel> host, IEnumerable<TModel> range)
    {
        foreach (var item in range) host.Add(item);
    }
}
