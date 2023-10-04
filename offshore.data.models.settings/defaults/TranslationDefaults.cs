namespace offshore.data.models.settings.defaults;

public static class TranslationDefaults
{
    public static void PopulateDatabase(IOffshoreDbContext context)
    {
        var en = new SupportedLanguage { Id = "en", Language = "English" };

        if(context.Contains(en)) { return;  }

        var es = new SupportedLanguage { Id = "es", Language = "Español" };
        context.AddToDbSet(en);
        context.AddToDbSet(es);

        var word = new TranslatableString { String = "HAWSER_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "hawser" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "guindaleza" });

        word = new TranslatableString { String = "PRESSURE_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "pressure" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "presión" });

        word = new TranslatableString { String = "MANIFOLD_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "manifold" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "colector" });

        word = new TranslatableString { String = "CURRENT_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "current" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "corriente" });

        word = new TranslatableString { String = "WAVE_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "wave" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "ola" });

        word = new TranslatableString { String = "WIND_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "wind" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "viento" });

        word = new TranslatableString { String = "TEMPEREATURE_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "temperature" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "temperatura" });

        word = new TranslatableString { String = "EXCURSION_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "excursion" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "excursión" });

        word = new TranslatableString { String = "ORIENTATION_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "orientation" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "orientación" });

        word = new TranslatableString { String = "VESSEL_EXCURSION_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "vessel excursion" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "excursión en barco" });

        word = new TranslatableString { String = "SHORE_PRESSURE_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "shore pressure" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "presión en tierra" });

        word = new TranslatableString { String = "BATTERY_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "battery" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "batería" });

        word = new TranslatableString { String = "SOLAR_STRING" };
        context.AddToDbSet(new Translation { Language = en, TranslatableString = word, Value = "solar" });
        context.AddToDbSet(new Translation { Language = es, TranslatableString = word, Value = "solar" });

        context.SaveChanges();
    }

}
