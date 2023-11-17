using Microsoft.EntityFrameworkCore;

namespace offshore.data;

public interface ILanguageSchema : IOffshoreDbConfiguration { }
public interface IUsersSchema : IOffshoreDbConfiguration { }
public interface ISettingsSchema : IOffshoreDbConfiguration { }
public interface IBusinessSchema : IOffshoreDbConfiguration { }
public interface IConfigurationSchema : IOffshoreDbConfiguration { }

public interface IOffshoreDbConfiguration
{
    string Schema { get; }
    string DatabaseType { get; }
    void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
}
