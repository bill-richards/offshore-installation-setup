using offshore.data.models.settings;
using offshore.services;

namespace offshore.data.parsing.models;

public class DefaultTelephonyDataModel : IJsonDataModel<DefaultTelephonyDataModel>
{
    public TelephoneType[]? TelephoneTypes { get; set; }
    public Country[]? Countries { get; set; }
    public CountryCode[]? CountryCodes { get; set; }
}

