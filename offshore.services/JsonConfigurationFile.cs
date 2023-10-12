using Microsoft.Extensions.Configuration;

namespace offshore.services;

public abstract class JsonConfigurationFile<TConfigurationType>
{
    public TConfigurationType GetConfiguration(string fileName, string sectionName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(fileName).Build();

        var section = config.GetSection(sectionName);

        return section.Get<TConfigurationType>()!;
    }
}
