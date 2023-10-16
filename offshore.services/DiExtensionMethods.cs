using Microsoft.Extensions.DependencyInjection;

namespace offshore.services;

public static class DiExtensionMethods
{
    public static void AddFactory<TService, TImpl>(this IServiceCollection services)
        where TService : class
        where TImpl : class, TService
    {
        services.AddTransient<TService, TImpl>();
        services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>()!);
        services.AddSingleton<IAbstractFactory<TService>, AbstractFactory<TService>>();

    }

    public static void AddFactory<TService, TImpl>(this IServiceCollection services, Func<IServiceProvider, TImpl> factory)
        where TService : class
        where TImpl : class, TService
    {
        services.AddTransient<TService, TImpl>(factory);
        services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>()!);
        services.AddSingleton<IAbstractFactory<TService>, AbstractFactory<TService>>();

    }
}