namespace offshore.services;

public class DataConfigurationFile : JsonConfigurationFile<DataConfigurationFile>, IDataConfigurationFile
{
    private const string ConfigurationFileName = "appsettings.json";
    public string SqliteSectionName => "lite";
    public string SqlExpressSectionName => "express";
    public string MongoSectionName => "mongo";
    public string SiteSectionName => "site";
    public string SchemataSectionName => "schemata";

    public DataConfigurationFile SiteConfiguration => GetConfiguration(ConfigurationFileName, SiteSectionName);
    public DataConfigurationFile LiteConfiguration => GetConfiguration(ConfigurationFileName, SqliteSectionName);
    public DataConfigurationFile ExpressConfiguration => GetConfiguration(ConfigurationFileName, SqlExpressSectionName);
    public DataConfigurationFile MongoConfiguration => GetConfiguration(ConfigurationFileName, MongoSectionName);
    public DataConfigurationFile SchemataConfiguration => GetConfiguration(ConfigurationFileName, SchemataSectionName);

    public uint? Licence { get; set; }
    public uint? Port { get; set; }
    public string? Store { get; set; }
    public string? Database { get; set; }
    public string? Server { get; set; }
    public string? DataFolder { get; set; }
    public string? UsersSchema { get; set; }
    public string? SettingsSchema { get; set; }
    public string? LanguageSchema { get; set; }
    public string? BusinessSchema { get; set; }
    public string? ConfigurationSchema { get; set; }
}
