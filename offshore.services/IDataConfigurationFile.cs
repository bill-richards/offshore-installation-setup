namespace offshore.services
{
    public interface IDataConfigurationFile
    {
        /**
         * configuration sections
         */
        DataConfigurationFile SchemataConfiguration { get; }
        DataConfigurationFile ExpressConfiguration { get; }
        DataConfigurationFile LiteConfiguration { get; }
        DataConfigurationFile MongoConfiguration { get; }
        DataConfigurationFile SiteConfiguration { get; }

        /**
         * configuration items
         */

        /// <summary>
        /// Available/Configured for ExpressConfiguration, MongoConfiguration
        /// </summary>
        string? Database { get; set; }
        /// <summary>
        /// Available/Configured for LiteConfiguration
        /// </summary>
        string? DataFolder { get; set; }
        /// <summary>
        /// Available/Configured for SiteConfiguration
        /// </summary>
        uint? Licence { get; set; }
        /// <summary>
        /// Available/Configured for MongoConfiguration
        /// </summary>
        uint? Port { get; set; }
        /// <summary>
        /// Available/Configured for ExpressConfiguration, MongoConfiguration
        /// </summary>
        string? Server { get; set; }
        /// <summary>
        /// Available/Configured for SiteConfiguration
        /// </summary>
        string? Store { get; set; }
        /// <summary>
        /// Available/Configured for SchemataConfiguration
        /// </summary>
        string? UsersSchema { get; set; }
        /// <summary>
        /// Available/Configured for SchemataConfiguration
        /// </summary>
        string? SettingsSchema { get; set; }
        /// <summary>
        /// Available/Configured for SchemataConfiguration
        /// </summary>
        string? LanguageSchema { get; set; }
        /// <summary>
        /// Available/Configured for SchemataConfiguration
        /// </summary>
        string? BusinessSchema { get; set; }
        /// <summary>
        /// Available/Configured for SchemataConfiguration
        /// </summary>
        string? ConfigurationSchema { get; set; }

        /**
         * configuration section names
         */
        string MongoSectionName { get; }
        string SiteSectionName { get; }
        string SqlExpressSectionName { get; }
        string SqliteSectionName { get; }
        string SchemataSectionName { get; }
    }
}