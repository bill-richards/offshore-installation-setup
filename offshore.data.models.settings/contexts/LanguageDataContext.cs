using Microsoft.EntityFrameworkCore;
using offshore.services;

namespace offshore.data.models.settings.contexts;

public class LanguageDataContext : OffshoreDbContext, ILanguageDataContext
{
    private readonly IDataConfigurationFile _configFile;

    public LanguageDataContext(ILanguageSchema databaseConfiguration, IDataConfigurationFile configFile, string databaseType = "SqlExpress")
        : base(databaseConfiguration, databaseType)
    {
        _configFile = configFile;
    }

    public DbSet<Language> Languages { get; set; }
    public DbSet<Translatable> Translatables { get; set; }
    public DbSet<Translation> Translations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_configFile.SchemataConfiguration.LanguageSchema);

        new Language().OnModelCreating(modelBuilder);
        new Translatable().OnModelCreating(modelBuilder);
        new Translation().OnModelCreating(modelBuilder);
    }
}
