using offshore.data.models.settings;

namespace offshore.data.parsing.models.loading;

public struct TelephonyDataEntities
{
    public TelephoneType[] TelephoneTypes { get; init; }
    public Country[] Countries { get; init; }
    public CountryCode[] CountryCodes { get; init; }
}
