using offshore.data.models.settings.contexts;

namespace offshore.data.models.settings.defaults;

public static class MeasurementDefaults
{
    public static void PopulateDatabase(ISettingsDataContext context)
    {
        var unit = new MeasurementUnit { Description = "Metric Tonne", Label = "tonne", Factor = 1.0, IsDefault = true };
        var existingUnit = context.FirstOrDefault<MeasurementUnit>(u => u.Description!.Equals(unit.Description));
        if (existingUnit == null) context.AddToDbSet(unit);
        else return;


        context.AddToDbSet(new MeasurementType { Name = "Mass", DefaultUnit = unit, IsDefault = true });
        context.AddRangeToDbSet(new[] {
            new MeasurementUnit { Description = "U.S Short Ton", Label = "U.S.ton", Factor = 1.102, IsDefault = true },
            new MeasurementUnit { Description = "U.K Long Ton", Label = "U.K.ton", Factor = 0.98425197, IsDefault = true },
            new MeasurementUnit { Description = "Kilogram", Label = "kg", Factor = 1000, IsDefault = true },
            new MeasurementUnit { Description = "Knot", Label = "knots", Factor = 1.94384443759918, IsDefault = true },
            new MeasurementUnit { Description = "Mile per hour", Label = "mph", Factor = 2.23693633079529, IsDefault = true },
            new MeasurementUnit { Description = "Kilometre per hour", Label = "km/h", Factor = 3.59999990463257, IsDefault = true },
            new MeasurementUnit { Description = "Feet per second", Label = "ft/s", Factor = 3.28083992004395, IsDefault = true },
            new MeasurementUnit { Description = "Millibar", Label = "mbar", Factor = 1000, IsDefault = true },
            new MeasurementUnit { Description = "Kilopascal", Label = "kPa", Factor = 100, IsDefault = true },
            new MeasurementUnit { Description = "Atmosphere", Label = "atm", Factor = 0.986923, IsDefault = true },
            new MeasurementUnit { Description = "Pound per square inch", Label = "psi", Factor = 14.503774, IsDefault = true },
            new MeasurementUnit { Description = "U.K. gallon per hour", Label = "U.K.gph", Factor = 220, IsDefault = true },
            new MeasurementUnit { Description = "U.S. gallon per hour", Label = "U.S.gph", Factor = 264.2, IsDefault = true },
            new MeasurementUnit { Description = "Barrel (petroleum) per hour", Label = "barrel/h", Factor = 6.29, IsDefault = true },
            new MeasurementUnit { Description = "Cubic foot per hour", Label = "ft\xB3/h", Factor = 35.31, IsDefault = true },
            new MeasurementUnit { Description = "Cubic inch per hour", Label = "in\xB3/h", Factor = 61024, IsDefault = true },
            new MeasurementUnit { Description = "Kilometre", Label = "km", Factor = 0.001, IsDefault = true },
            new MeasurementUnit { Description = "Feet", Label = "ft", Factor = 3.28084, IsDefault = true },
            new MeasurementUnit { Description = "Mile", Label = "mi", Factor = 0.000621, IsDefault = true },
            new MeasurementUnit { Description = "Nautical mile", Label = "NM", Factor = 1852, IsDefault = true },
            new MeasurementUnit { Description = "Inch", Label = "in", Factor = 39.370079, IsDefault = true },
            new MeasurementUnit { Description = "Yard", Label = "yd", Factor = 1.093613, IsDefault = true },
            new MeasurementUnit { Description = "Millibar", Label = "mbar", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Kilopascal", Label = "kPa", Factor = 0.1, IsDefault = true },
            new MeasurementUnit { Description = "Pascal", Label = "Pa", Factor = 100, IsDefault = true },
            new MeasurementUnit { Description = "Atmosphere", Label = "atm", Factor = 0.000986923, IsDefault = true },
            new MeasurementUnit { Description = "Pound per square inch", Label = "psi", Factor = 0.014503774, IsDefault = true },
            new MeasurementUnit { Description = "Minutes", Label = "minutes", Factor = 0.01666666666666, IsDefault = true },
            new MeasurementUnit { Description = "Hours", Label = "hours", Factor = 0.00027778, IsDefault = true },
            new MeasurementUnit { Description = "Degree Fahrenheit", Label = $"{"\xB0"}F", Factor = 1.8, IsDefault = true },
            new MeasurementUnit { Description = "Degree Celsius", Label = $"{"\xB0"}C", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Bar", Label = "bar", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Cubic metre per hour", Label = "m\xB3/h", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Metre", Label = "m", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Atmospheric Bar", Label = "bar", Factor = 0.001, IsDefault = true },
            new MeasurementUnit { Description = "Volts", Label = "V", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Percentage", Label = "%", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Degrees", Label = "\xB0", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Seconds", Label = "seconds", Factor = 1, IsDefault = true },
            new MeasurementUnit { Description = "Metre per second", Label = "m/s", Factor = 1, IsDefault = true }        
        });
        context.SaveChanges();

        context.AddRangeToDbSet(new[]
        {
            new MeasurementType {
                Name = "Speed",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description!.Equals("Metre per second")), IsDefault = true
            },
            new MeasurementType {
                Name = "Temperature",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Degree Celsius")), IsDefault = true
            },
            new MeasurementType
            {
                Name = "Product Pressure",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Bar")), IsDefault = true
            },
            new MeasurementType
            {
                Name = "Flow",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Cubic metre per hour")), IsDefault = true
            },
            new MeasurementType
            {
                Name = "Distance",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Metre")), IsDefault = true
            },
            new MeasurementType
            {
                Name = "Atmospheric pressure",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Atmospheric Bar")), IsDefault = true
            },
            new MeasurementType
            {
                Name = "Power",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Volts")), IsDefault = true
            },
            new MeasurementType
            {
                Name = "Percentage",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Percentage")), IsDefault = true
            },
            new MeasurementType
            {
                Name = "Bearing",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Degrees")), IsDefault = true
            },
            new MeasurementType
            {
                Name = "Time",
                DefaultUnit = context.FirstOrDefault<MeasurementUnit>(m => m.Description !.Equals("Seconds")), IsDefault = true
            }
        });
        context.SaveChanges();
    }
}
