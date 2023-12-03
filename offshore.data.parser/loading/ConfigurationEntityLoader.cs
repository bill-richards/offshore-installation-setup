using offshore.data.models.settings;
using offshore.data.models.settings.contexts;
using offshore.data.parsing.models;

namespace offshore.data.parsing.loading;

public static class ConfigurationEntityLoader
{
    public static void PopulateDatabase(IConfigurationDataContext context, DefaultConfigurationDataModel data)
    {
        if (context.GetNamedRecord<Module>(data.Modules![0].Name!) is null)
            context.AddRangeToDbSet(data.Modules).And.SaveChanges();

        if (context.GetNamedRecord<Telemetry>(data.Telemetries![0].Name!) is null)
            context.AddRangeToDbSet(data.Telemetries).And.SaveChanges();

        if (!context.GetDbSet<Receiver>().Any(r => r.Name == data.Receivers![0].Name!))
            context.AddRangeToDbSet<Receiver>(data.Receivers!).And.SaveChanges();

        if (context.GetNamedRecord<Sensor>(data.Sensors![0].Name!) is null)
        {
            //foreach (var sensor in data.Sensors)
            //{
            //    sensor.Telemetry = context.GetNamedRecord<Telemetry>(sensor.TelemetryRef!);
            //}
            context.AddRangeToDbSet(data.Sensors).And.SaveChanges();
        }

        if (context.GetNamedRecord<MeasurementType>(data.MeasurementTypes[0].Name!) is null)
            context.AddRangeToDbSet(data.MeasurementTypes).And.SaveChanges();

        if (context.GetNamedRecord<MeasurementUnit>(data.MeasurementUnits[0].Name!) is null)
        {
            //foreach (var unit in data.MeasurementUnits)
            //{
            //    if (unit.MeasurementTypeRef is not null)
            //        unit.MeasurementType = context.GetNamedRecord<MeasurementType>(unit.MeasurementTypeRef);
            //}
             context.AddRangeToDbSet(data.MeasurementUnits).And.SaveChanges();
        }
    }
}
