using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.parsing.models;

namespace offshore.data.parsing.loading;

public static class LanguageEntityLoader
{
    public static void PopulateDatabase(ILanguageDataContext context, DefaultLanguageDataModel data)
    {
        if (context.GetNamedRecord<data.models.settings.Language>(data.Languages![0].Name!) is null)
            context.AddRangeToDbSet(data.Languages).And.SaveChanges();

        if (context.GetNamedRecord<Translatable>(data.Translatables![0].Name!) is null)
            context.AddRangeToDbSet(data.Translatables).And.SaveChanges();

        var reference = data.Translations![0].TranslatableRef;
        if (!context.GetDbSet<Translation>().Any(c => c.Translatable!.Name == reference))
        {
            foreach (var translation in data.Translations)
            {
                translation.Language = context.GetNamedRecord<data.models.settings.Language>(translation.LanguageRef!);
                translation.Translatable = context.GetNamedRecord<Translatable>(translation.TranslatableRef!);
            }
            context.AddRangeToDbSet(data.Translations!).And.SaveChanges();
        }
    }
}
