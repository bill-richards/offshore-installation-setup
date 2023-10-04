namespace offshore.services;

public interface IAbstractFactory<TInterface>
{
    TInterface Create();
}
