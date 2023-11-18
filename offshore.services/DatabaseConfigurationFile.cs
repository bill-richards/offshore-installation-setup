namespace offshore.services;

public class DatabaseConfigurationFile : JsonConfigurationFile<DatabaseConfigurationFile>, IDatabaseConfigurationFile
{
    private const string ConfigurationFileName = "appsettings.json";
    public string SqliteSectionName => "lite";
    public string SqlExpressSectionName => "express";
    public string MongoSectionName => "mongo";
    public string SiteSectionName => "site";
    public string SchemataSectionName => "schemata";

    public DatabaseConfigurationFile SiteConfiguration => GetConfiguration(ConfigurationFileName, SiteSectionName);
    public DatabaseConfigurationFile LiteConfiguration => GetConfiguration(ConfigurationFileName, SqliteSectionName);
    public DatabaseConfigurationFile ExpressConfiguration => GetConfiguration(ConfigurationFileName, SqlExpressSectionName);
    public DatabaseConfigurationFile MongoConfiguration => GetConfiguration(ConfigurationFileName, MongoSectionName);
    public DatabaseConfigurationFile SchemataConfiguration => GetConfiguration(ConfigurationFileName, SchemataSectionName);

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
