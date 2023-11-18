using offshore.data.models.settings;

namespace offshore.data.parsing.models.loading;

public struct ConfigurationDataEntities
{
    public MeasurementType[] MeasurementTypes { get; set; }
    public MeasurementUnit[] MeasurementUnits { get; set; }
    public Receiver[] Receivers { get; set; }
    public Telemetry[] Telemetries { get; set; }
    public Sensor[] Sensors { get; set; }
    public Module[] Modules { get; set; }
}
