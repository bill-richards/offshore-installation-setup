using offshore.data.models.settings;
using offshore.services;

namespace offshore.data.parsing.models;

public class DefaultLanguageDataModel : IJsonDataModel<DefaultLanguageDataModel>
{
    public offshore.data.models.settings.Language[] Languages { get; set; } = [];
    public Translatable[] Translatables { get; set; } = [];
    public Translation[] Translations { get; set; } = [];
}

