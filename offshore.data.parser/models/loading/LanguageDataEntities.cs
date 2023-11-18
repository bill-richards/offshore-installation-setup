using offshore.data.models.settings;

namespace offshore.data.parsing.models.loading;

public struct LanguageDataEntities
{
    public Language[] Languages { get; init; }
    public Translatable[] Translatables { get; init; }
    public Translation[] Translations { get; init; }
}
