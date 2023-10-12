namespace offshore.services;

public class DataConfigurationFile : JsonConfigurationFile<DataConfigurationFile>
{
    private const string ConfigurationFileName = "appsettings.json";
    private const string SqliteSectionName = "lite";
    private const string SqlExpressSectionName = "express";
    private const string SiteSectionName = "site";

    public DataConfigurationFile SiteConfiguration => GetConfiguration(ConfigurationFileName, SiteSectionName);
    public DataConfigurationFile LiteConfiguration => GetConfiguration(ConfigurationFileName, SqliteSectionName);
    public DataConfigurationFile ExpressConfiguration => GetConfiguration(ConfigurationFileName, SqlExpressSectionName);

    public uint? Licence { get; set; }
    public string? Store { get; set; }
    public string? Database { get; set; }
    public string? Server { get; set; }
    public string? DataFolder { get; set; }
}
