using Microsoft.EntityFrameworkCore;

namespace offshore.data.models.settings.defaults;

public static class TranslationDefaults
{

    public static void PopulateDatabase(IOffshoreDbContext context)
    {
        const string ID_FIELD = "Id";

        var en = new SupportedLanguage() { ShortName = "en", Name = "English" };
        var existingLanguage = context.FirstOrDefault<SupportedLanguage>(l => l.ShortName!.Equals(en.ShortName));
        if (existingLanguage == null) context.AddToDbSet(en);
        else en = existingLanguage;

        var es = new SupportedLanguage() { ShortName = "es", Name = "Español" };
        existingLanguage = context.FirstOrDefault<SupportedLanguage>(l => l.ShortName!.Equals(es.ShortName));
        if (existingLanguage == null) context.AddToDbSet(es);
        else es = existingLanguage;

        var translations = context.GetDbSet<Translation>().Include(s => s.Translatable);


        var word = new Translatable { Value = "HAWSER_STRING" };
        var existingString = context.FirstOrDefault<Translatable>(s => s.Value!.Equals(word.Value));
        if (existingString == null) context.AddToDbSet(word);
        else word = existingString;

        var en_translation = new Translation { Language = en, Translatable = word, Value = "hawser" };
        var existingTranslation = translations.FirstOrDefault(t => EF.Property<uint>(t.Language!, ID_FIELD).Equals(context.Entry(en).Property<uint>(ID_FIELD).CurrentValue!)
                                && EF.Property<uint>(t.Translatable!, ID_FIELD).Equals(context.Entry(word).Property<uint>(ID_FIELD).CurrentValue!));
        if (existingTranslation == null) context.AddToDbSet(en_translation);
        var es_translation = new Translation { Language = es, Translatable = word, Value = "guindaleza" };
        existingTranslation = translations.FirstOrDefault(t => EF.Property<uint>(t.Language!, ID_FIELD).Equals(context.Entry(es).Property<uint>(ID_FIELD).CurrentValue!)
                                && EF.Property<uint>(t.Translatable!, ID_FIELD).Equals(context.Entry(word).Property<uint>(ID_FIELD).CurrentValue!));
        if (existingTranslation == null) context.AddToDbSet(es_translation);

        word = new Translatable { Value = "PRESSURE_STRING" };
        existingString = context.FirstOrDefault<Translatable>(s => s.Value!.Equals(word.Value));
        if (existingString == null) context.AddToDbSet(word);
        else return;

        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "pressure" },
            new Translation { Language = es, Translatable = word, Value = "presión" }
        });

        word = new Translatable { Value = "MANIFOLD_STRING" };
        context.AddToDbSet(word);
                context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "manifold" },
            new Translation { Language = es, Translatable = word, Value = "colector" },
        });

        word = new Translatable { Value = "CURRENT_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "current" },
            new Translation { Language = es, Translatable = word, Value = "corriente" } 
        });

        word = new Translatable { Value = "WAVE_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "wave" },
            new Translation { Language = es, Translatable = word, Value = "ola" } 
        });

        word = new Translatable { Value = "WIND_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "wind" },
            new Translation { Language = es, Translatable = word, Value = "viento" } 
        });

        word = new Translatable { Value = "TEMPEREATURE_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "temperature" },
            new Translation { Language = es, Translatable = word, Value = "temperatura" } 
        });

        word = new Translatable { Value = "EXCURSION_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "excursion" },
            new Translation { Language = es, Translatable = word, Value = "excursión" }
        });

        word = new Translatable { Value = "ORIENTATION_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "orientation" },
            new Translation { Language = es, Translatable = word, Value = "orientación" }
        });

        word = new Translatable { Value = "VESSEL_EXCURSION_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "vessel excursion" },
            new Translation { Language = es, Translatable = word, Value = "excursión en barco" }
        });

        word = new Translatable { Value = "SHORE_PRESSURE_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "shore pressure" },
            new Translation { Language = es, Translatable = word, Value = "presión en tierra" }
        });

        word = new Translatable { Value = "BATTERY_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "battery" },
            new Translation { Language = es, Translatable = word, Value = "batería" }
        });

        word = new Translatable { Value = "SOLAR_STRING" };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "solar" },
            new Translation { Language = es, Translatable = word, Value = "solar" }
        });

        context.SaveChanges();
    }

}
