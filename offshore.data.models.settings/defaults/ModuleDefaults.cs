namespace offshore.data.models.settings.defaults;


public static class ModuleDefaults
{
    public static void PopulateDatabase(IOffshoreDbContext context)
    {
        var module = new Module { Name = "HAWSER TENSION", GraphMinimum = 60 };
        if (context.Contains(module)) { return;  }

        context.AddToDbSet(module);
        context.AddToDbSet(new Module { Name = "PIPE PRESSURE", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "TANKER MANIFOLD PRESSURE", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "CURRENT", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "WAVE", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "WIND", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "BUOY TEMPERATURE", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "BUOY EXCURSION", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "BUOY ORIENTATION", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "TANKER EXCURSION", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "SHORE PRESSURE", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "SHORE FLOW RATE", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "POWER SYSTEM", GraphMinimum = 1440 });
        context.AddToDbSet(new Module { Name = "LEAK DETECTION", GraphMinimum = 60 });
        context.AddToDbSet(new Module { Name = "WEATHER", GraphMinimum = 1440 });
        context.AddToDbSet(new Module { Name = "INCLINATION", GraphMinimum = 60 });

        context.SaveChanges();
    }
}
