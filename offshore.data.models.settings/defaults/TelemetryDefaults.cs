using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings.defaults;

public static class TelemetryDefaults
{
    public static void PopulateDatabase(ISettingsDataContext context)
    {
        var receiver = new Receiver { Type = "USB", IsDefault = true };
        var existing = context.FirstOrDefault<Receiver>(r => r.Type!.Equals(receiver.Type));
        if (existing == null)
        {
            context.AddRangeToDbSet(new[]
            {
                receiver,
                new Receiver { Type = "Serial", IsDefault = true },
                new Receiver { Type = "Tcp", IsDefault = true }
            });
        }
        if (context.ChangeTracker.HasChanges()) context.SaveChanges();

        var telemetry = context.GetNamedRecord<Telemetry>("$COMMS");
        if (telemetry == null)
        {
            context.AddRangeToDbSet(new[]
            {
                new Telemetry { Name = "$COMMS", IsActive = true, IsDefault = true },
                new Telemetry { Name = "$OSANA", IsDefault = true },
                new Telemetry { Name = "$OSGP1", IsDefault = true },
                new Telemetry { Name = "$OSGP2", IsDefault = true },
                new Telemetry { Name = "$OSSWO", IsDefault = true },
                new Telemetry { Name = "$OSVSB", IsDefault = true },
                new Telemetry { Name = "$OSAWA", IsDefault = true },
                new Telemetry { Name = "$OSFPA", IsDefault = true },
                new Telemetry { Name = "$OSSA" , IsDefault = true },
                new Telemetry { Name = "$OWGPS", IsDefault = true },
                new Telemetry { Name = "$OSANP", IsDefault = true },
                new Telemetry { Name = "$OSMXM", IsDefault = true },
                new Telemetry { Name = "$OSALH", IsDefault = true },
            });
        }
        if(context.ChangeTracker.HasChanges()) 
            context.SaveChanges();

        var sensor = context.GetNamedRecord<Sensor>("Comms Check");
        if (sensor == null)
        {
            context.AddRangeToDbSet<Sensor>(new[] {
                new Sensor
                {
                    Name = "Comms",
                    MaximumValue = 100,
                    DataArrayPosition = "0",
                    AlarmInterval = 100,
                    Telemetry = context.GetNamedRecord<Telemetry>("$COMMS"), IsDefault = true
                },
                new Sensor
                {
                    Name = "Load",
                    MaximumValue = 250,
                    DataArrayPosition = "2",
                    AlarmInterval=10,
                    Telemetry = context.GetNamedRecord<Telemetry>("$OSANA"), IsDefault = true
                },
                new Sensor
                {
                    Name = "Flow",
                    MaximumValue = 25,
                    MinimumValue = -2,
                    DataArrayPosition = "6",
                    DecimalPlaces = 2,
                    AlarmInterval=10,
                    Telemetry = context.GetNamedRecord<Telemetry>("$OSANA"), IsDefault = true
                },
                new Sensor
                {
                    Name = "WindSpeed",
                    MaximumValue = 100,
                    DataArrayPosition = "6",
                    DecimalPlaces = 2,
                    AlarmInterval=10,
                    Telemetry = context.GetNamedRecord<Telemetry>("$OSSWO"), IsDefault = true
                },
            });
        }
        if (context.ChangeTracker.HasChanges()) 
            context.SaveChanges();
    }
}
