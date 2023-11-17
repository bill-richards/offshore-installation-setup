using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings.contexts;

public interface ILanguageDataContext : IOffshoreDbContext
{
    DbSet<Language> Languages { get; }
    DbSet<Translatable> Translatables { get; }
    DbSet<Translation> Translations { get; }
}