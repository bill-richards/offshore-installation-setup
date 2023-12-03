using offshore.data.models.settings;
using offshore.services;

namespace offshore.data.parsing.models;

public class DefaultConfigurationDataModel : IJsonDataModel<DefaultConfigurationDataModel>
{
    public MeasurementType[] MeasurementTypes { get; set; } = [];
    public MeasurementUnit[] MeasurementUnits { get; set; } = [];
    public ReceiverJsonModel[] Receivers { get; set; } = [];
    public Telemetry[] Telemetries { get; set; } = [];
    public Sensor[] Sensors { get; set; } = [];
    public Module[] Modules { get; set; } = [];
}

