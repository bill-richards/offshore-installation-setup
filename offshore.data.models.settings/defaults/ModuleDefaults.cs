using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings.defaults;


public static class ModuleDefaults
{
    public static void PopulateDatabase(ISettingsDataContext context)
    {
        var module = new Module { Name = "HAWSER TENSION", GraphMinimum = 60, IsDefault = true };
        if (context.GetNamedRecord<Module>(module.Name) != null) return;

        context.AddRangeToDbSet(new[]{
            module,
            new() { Name = "PIPE PRESSURE", GraphMinimum = 60, IsDefault = true },
            new() { Name = "TANKER MANIFOLD PRESSURE", GraphMinimum = 60, IsDefault = true },
            new() { Name = "CURRENT", GraphMinimum = 60, IsDefault = true },
            new() { Name = "WAVE", GraphMinimum = 60, IsDefault = true },
            new() { Name = "WIND", GraphMinimum = 60, IsDefault = true },
            new() { Name = "BUOY TEMPERATURE", GraphMinimum = 60, IsDefault = true },
            new() { Name = "BUOY EXCURSION", GraphMinimum = 60, IsDefault = true },
            new() { Name = "BUOY ORIENTATION", GraphMinimum = 60, IsDefault = true },
            new() { Name = "TANKER EXCURSION", GraphMinimum = 60, IsDefault = true },
            new() { Name = "SHORE PRESSURE", GraphMinimum = 60, IsDefault = true },
            new() { Name = "SHORE FLOW RATE", GraphMinimum = 60, IsDefault = true },
            new() { Name = "POWER SYSTEM", GraphMinimum = 1440, IsDefault = true },
            new() { Name = "LEAK DETECTION", GraphMinimum = 60, IsDefault = true },
            new() { Name = "WEATHER", GraphMinimum = 1440, IsDefault = true },
            new() { Name = "INCLINATION", GraphMinimum = 60, IsDefault = true }
        });

        context.SaveChanges();
    }
}
