using offshore.services;

namespace offshore.data.parsing.models;

public class DefaultTelephonyDataModel : IJsonDataModel<DefaultTelephonyDataModel>
{
    public data.models.settings.TelephoneType[] TelephoneTypes { get; set; } = [];
    public data.models.settings.Country[] Countries { get; set; } = [];
    public data.models.settings.CountryCode[] CountryCodes { get; set; } = [];
}

