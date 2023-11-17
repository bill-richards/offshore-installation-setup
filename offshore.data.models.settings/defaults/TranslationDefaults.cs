using Microsoft.EntityFrameworkCore;
using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings.defaults;
public static class TranslationDefaults
    {
        public static void PopulateDatabase(ILanguageDataContext context)
        {
            const string ID_FIELD = "Id";

        var en = new Language() { ShortName = "en", Name = "English", IsDefault = true };
        var existingLanguage = context.FirstOrDefault<Language>(l => l.ShortName!.Equals(en.ShortName));
        if (existingLanguage == null) context.AddToDbSet(en);
        else en = existingLanguage;

        var es = new Language() { ShortName = "es", Name = "Español" , IsDefault = true };
        existingLanguage = context.FirstOrDefault<Language>(l => l.ShortName!.Equals(es.ShortName));
        if (existingLanguage == null) context.AddToDbSet(es);
        else es = existingLanguage;

        var translations = context.GetDbSet<Translation>().Include(s => s.Translatable);


        var word = new Translatable { Name = "HAWSER_STRING" , IsDefault = true };
        var existingString = context.FirstOrDefault<Translatable>(s => s.Name!.Equals(word.Name));
        if (existingString == null) context.AddToDbSet(word);
        else word = existingString;

        var en_translation = new Translation { Language = en, Translatable = word, Value = "hawser", IsDefault = true };
        var existingTranslation = translations.FirstOrDefault(t => EF.Property<uint>(t.Language!, ID_FIELD).Equals(context.Entry(en).Property<uint>(ID_FIELD).CurrentValue!)
                                && EF.Property<uint>(t.Translatable!, ID_FIELD).Equals(context.Entry(word).Property<uint>(ID_FIELD).CurrentValue!));
        if (existingTranslation == null) context.AddToDbSet(en_translation);
        var es_translation = new Translation { Language = es, Translatable = word, Value = "guindaleza", IsDefault = true };
        existingTranslation = translations.FirstOrDefault(t => EF.Property<uint>(t.Language!, ID_FIELD).Equals(context.Entry(es).Property<uint>(ID_FIELD).CurrentValue!)
                                && EF.Property<uint>(t.Translatable!, ID_FIELD).Equals(context.Entry(word).Property<uint>(ID_FIELD).CurrentValue!));
        if (existingTranslation == null) context.AddToDbSet(es_translation);

        word = new Translatable { Name = "PRESSURE_STRING", IsDefault = true };
        existingString = context.FirstOrDefault<Translatable>(s => s.Name!.Equals(word.Name));
        if (existingString == null) context.AddToDbSet(word);
        else return;

        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "pressure", IsDefault = true },
            new Translation { Language = es, Translatable = word, Value = "presión" , IsDefault = true}
        });

        word = new Translatable { Name = "MANIFOLD_STRING" , IsDefault = true };
        context.AddToDbSet(word);
                context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "manifold" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "colector" , IsDefault = true},
        });

        word = new Translatable { Name = "CURRENT_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "current" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "corriente" , IsDefault = true} 
        });

        word = new Translatable { Name = "WAVE_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "wave" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "ola" , IsDefault = true} 
        });

        word = new Translatable { Name = "WIND_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "wind" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "viento" , IsDefault = true} 
        });

        word = new Translatable { Name = "TEMPEREATURE_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "temperature" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "temperatura" , IsDefault = true} 
        });

        word = new Translatable { Name = "EXCURSION_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "excursion" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "excursión" , IsDefault = true}
        });

        word = new Translatable { Name = "ORIENTATION_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "orientation" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "orientación" , IsDefault = true}
        });

        word = new Translatable { Name = "VESSEL_EXCURSION_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "vessel excursion" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "excursión en barco" , IsDefault = true}
        });

        word = new Translatable { Name = "SHORE_PRESSURE_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "shore pressure" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "presión en tierra" , IsDefault = true}
        });

        word = new Translatable { Name = "BATTERY_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "battery" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "batería" , IsDefault = true}
        });

        word = new Translatable { Name = "SOLAR_STRING" , IsDefault = true };
        context.AddToDbSet(word);
        context.AddRangeToDbSet(new[]
        {
            new Translation { Language = en, Translatable = word, Value = "solar" , IsDefault = true},
            new Translation { Language = es, Translatable = word, Value = "solar" , IsDefault = true}
        });

        context.SaveChanges();
    }

}
