namespace offshore.services;

public class AbstractFactory<TService> : IAbstractFactory<TService>
{
    private readonly Func<TService> _factory;

    public AbstractFactory(Func<TService> factory)
        => _factory = factory;

    public TService Create() => _factory();
}
