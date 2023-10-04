using Microsoft.Extensions.Configuration;

namespace offshore.services;

public abstract class JsonConfigurationFile<TConfigurationType>
{
    private static TConfigurationType? _theConfiguration;

    public static TConfigurationType GetConfiguration(string fileName, string topmostSectionName)
    {
        if (_theConfiguration != null) return _theConfiguration;

        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(fileName).Build();

        var section = config.GetSection(topmostSectionName);
        _theConfiguration = section.Get<TConfigurationType>();

        return _theConfiguration!;
    }
}
