namespace offshore.services;

public class DataConfigurationFile : JsonConfigurationFile<DataConfigurationFile>
{
    private const string ConfigurationFileName = "appsettings.json";
    private const string TopmostSectionName = "data";

    public DataConfigurationFile Configuration => GetConfiguration(ConfigurationFileName, TopmostSectionName);

    public string? DataFolder { get; set; }
    public uint Licence { get; set; }
}
