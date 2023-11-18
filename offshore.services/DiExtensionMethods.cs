using Microsoft.Extensions.DependencyInjection;

namespace offshore.services;

public static class DiExtensionMethods
{
    public static void AddFactory<TService, TImplementation>(this IServiceCollection services)
        where TService : class
        where TImplementation : class, TService
    {
        services.AddTransient<TService, TImplementation>();
        services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>()!);
        services.AddSingleton<IAbstractFactory<TService>, AbstractFactory<TService>>();

    }

    public static void AddFactory<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> factory)
        where TService : class
        where TImplementation : class, TService
    {
        services.AddTransient<TService, TImplementation>(factory);
        services.AddSingleton<Func<TService>>(x => () => x.GetService<TService>()!);
        services.AddSingleton<IAbstractFactory<TService>, AbstractFactory<TService>>();

    }
}