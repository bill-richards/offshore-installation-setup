using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.parsing.models.loading;

namespace offshore.data.parsing.loading;

public static class ConfigurationEntityLoader
{
    public static void PopulateDatabase(IConfigurationDataContext context, ConfigurationDataEntities data)
    {
        if (context.GetNamedRecord<Module>(data.Modules[0].Name!) is null)
        {
            context.AddRangeToDbSet(data.Modules);
            context.SaveChanges();
        }
        if (context.GetNamedRecord<Telemetry>(data.Telemetries[0].Name!) is null)
        {
            context.AddRangeToDbSet(data.Telemetries!);
            context.SaveChanges();
        }
        if (!context.GetDbSet<Receiver>().Any(r => r.Type == data.Receivers[0].Type!))
        {
            context.AddRangeToDbSet(data.Receivers);
            context.SaveChanges();
        }

        if (context.GetNamedRecord<Sensor>(data.Sensors[0].Name!) is null)
        {
            foreach (var sensor in data.Sensors)
            {
                sensor.Telemetry = context.GetNamedRecord<Telemetry>(sensor.TelemetryRef!);
            }
            context.AddRangeToDbSet(data.Sensors);
            context.SaveChanges();
        }

        if (context.GetNamedRecord<MeasurementType>(data.MeasurementTypes[0].Name!) is null)
        {
            context.AddRangeToDbSet(data.MeasurementTypes);
            context.SaveChanges();
        }

        if (context.GetNamedRecord<MeasurementUnit>(data.MeasurementUnits[0].Name!) is null)
        {
            foreach (var unit in data.MeasurementUnits)
            {
                if (unit.MeasurementTypeRef is not null)
                    unit.MeasurementType = context.GetNamedRecord<MeasurementType>(unit.MeasurementTypeRef);

                context.AddToDbSet(unit);
            }
            context.SaveChanges();
        }
    }
}
