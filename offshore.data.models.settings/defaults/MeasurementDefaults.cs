namespace offshore.data.models.settings.defaults;

public static class MeasurementDefaults
{
    public static void PopulateDatabase(IOffshoreDbContext context)
    {
        var unit = new MeasurementUnit { Description = "Metric Tonne", Label = "tonne", Factor = 1.0 };
        if (context.Contains(unit)) { return; }


        var measurement = new Measurement { Name = "Mass", DefaultUnit = unit };
        context.AddToDbSet(unit);
        var measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "U.S Short Ton", Label = "U.S.ton", Factor = 1.102 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "U.K Long Ton", Label = "U.K.ton", Factor = 0.98425197 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Kilogram", Label = "kg", Factor = 1000 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Metre per second", Label = "m/s", Factor = 1 };
        measurement = new Measurement { Name = "Speed", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Knot", Label = "knots", Factor = 1.94384443759918 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Mile per hour", Label = "mph", Factor = 2.23693633079529 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Kilometre per hour", Label = "km/h", Factor = 3.59999990463257 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Feet per second", Label = "ft/s", Factor = 3.28083992004395 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Degree Celsius", Label = "\xB0 C", Factor = 1 };
        measurement = new Measurement { Name = "Temperature", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Degree Fahrenheit", Label = "\xB0 F", Factor = 1.8 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Bar", Label = "bar", Factor = 1 };
        measurement = new Measurement { Name = "Product Pressure", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Millibar", Label = "mbar", Factor = 1000 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Kilopascal", Label = "kPa", Factor = 100 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Atmosphere", Label = "atm", Factor = 0.986923 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Pound per square inch", Label = "psi", Factor = 14.503774 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Cubic metre per hour", Label = "m\xB3/h", Factor = 1 };
        measurement = new Measurement { Name = "Flow", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "U.K. gallon per hour", Label = "U.K.gph", Factor = 220 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "U.S. gallon per hour", Label = "U.S.gph", Factor = 264.2 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Barrel (petroleum) per hour", Label = "barrel/h", Factor = 6.29 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Cubic foot per hour", Label = "ft\xB3/h", Factor = 35.31 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Cubic inch per hour", Label = "in\xB3/h", Factor = 61024 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Metre", Label = "m", Factor = 1 };
        measurement = new Measurement { Name = "Distance", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Kilometre", Label = "km", Factor = 0.001 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Feet", Label = "ft", Factor = 3.28084 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Mile", Label = "mi", Factor = 0.000621 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Nautical mile", Label = "NM", Factor = 1852 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Inch", Label = "in", Factor = 39.370079 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Yard", Label = "yd", Factor = 1.093613 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Bar", Label = "bar", Factor = 0.001 };
        measurement = new Measurement { Name = "Atmospheric pressure", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Millibar", Label = "mbar", Factor = 1 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Kilopascal", Label = "kPa", Factor = 0.1 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Pascal", Label = "Pa", Factor = 100 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Atmosphere", Label = "atm", Factor = 0.000986923 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Pound per square inch", Label = "psi", Factor = 0.014503774 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Volts", Label = "V", Factor = 1 };
        measurement = new Measurement { Name = "Power", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Percentage", Label = "%", Factor = 1 };
        measurement = new Measurement { Name = "Percentage", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Degrees", Label = "\xB0", Factor = 1 };
        measurement = new Measurement { Name = "Bearing", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Seconds", Label = "seconds", Factor = 1 };
        measurement = new Measurement { Name = "Time", DefaultUnit = unit };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Minutes", Label = "minutes", Factor = 0.01666666666666 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        unit = new MeasurementUnit { Description = "Hours", Label = "hours", Factor = 0.00027778 };
        context.AddToDbSet(unit);
        measurementDataUnit = new MeasurementDataUnit { Measurement = measurement, MeasurementUnit = unit };
        context.AddToDbSet(measurementDataUnit);

        context.SaveChanges();
    }
}
