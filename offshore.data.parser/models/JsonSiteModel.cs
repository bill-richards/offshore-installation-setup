using offshore.data.models.settings;
using offshore.services;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace offshore.data.parsing.models;

public class JsonSiteModel : IJsonDataModel<JsonSiteModel>
{
    public LanguageJsonModel[] Languages { get; init; } = [];
    public Name[] Names { get; init; } = [];
    public CountryJsonModel[] Countries { get; init; } = [];
    public CountryCodeJsonModel[] CountryCodes { get; init; } = [];
    public EmailJsonModel[] Emails { get; init; } = [];
    public TelephoneTypeJsonModel[] TelephoneTypes { get; init; } = [];
    public TelephoneNumberJsonModel[] TelephoneNumbers { get; init; } = [];
    public AddressJsonModel[] Addresses { get; init; } = [];
    public ContactJsonModel[] Contacts { get; init; } = [];
    public LocationJsonModel[] Locations { get; init; } = [];
    public CompanyJsonModel[] Companies { get; init; } = [];
    public UserJsonModel[] Users { get; init; } = [];
    public SiteJsonModel[] Sites { get; init; } = [];
    public SiteConfigurationJsonModel[] SiteConfigurations { get; init; } = [];
    public ReceiverJsonModel[] Receivers { get; init; } = [];
}

public class ReceiverJsonModel : Receiver
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = ""; 
}
public class SiteConfigurationJsonModel : SiteConfiguration
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("SyncUserRef"), NotMapped] public string UserReference { get; set; } = "";
    [JsonPropertyName("NameRef"), NotMapped] public string NameReference { get; set; } = "";
    [JsonPropertyName("ReceiverTypeRef"), NotMapped] public string ReceiverTypeReference { get; set; } = "";

}
public class SiteJsonModel : Site
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("CompanyRef"), NotMapped] public string CompanyReference { get; set; } = "";
    [JsonPropertyName("NameRef"), NotMapped] public string NameReference { get; set; } = "";
    [JsonPropertyName("LocationRef"), NotMapped] public string LocationReference { get; set; } = "";
    [JsonPropertyName("ConfigurationRef"), NotMapped] public string ConfigurationReference { get; set; } = "";
    [JsonPropertyName("UserRefs"), NotMapped] public string[] UserReferences { get; set; } = [];
}
public class LanguageJsonModel : Language
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
}
public class Name
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [NotMapped] public string Value { get; set; } = "";

}
public class CountryJsonModel : Country
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
}
public class CountryCodeJsonModel : CountryCode
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
}
public class EmailJsonModel
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [NotMapped] public string Value { get; set; } = "";
}
public class TelephoneTypeJsonModel : TelephoneType
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
}
public class TelephoneNumberJsonModel : TelephoneNumber
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("CountryCodeRef"), NotMapped] public string CountryCodeReference { get; set; } = "";
    [JsonPropertyName("TypeRef"), NotMapped] public string TypeReference { get; set; } = "";
}
public class AddressJsonModel : Address
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("CountryRef"), NotMapped] public string CountryReference { get; set; } = "";
}
public class ContactJsonModel : Contact
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("NameRef"), NotMapped] public string NameReference { get; set; } = "";
    [JsonPropertyName("TelephoneRefs"), NotMapped] public string[] TelephoneReferences { get; set; } = [];

}
public class LocationJsonModel : Location
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("AddressRef"), NotMapped] public string AddressReference { get; set; } = "";
    [JsonPropertyName("ContactRefs"), NotMapped] public string[] ContactReferences { get; set; } = [];
}
public class CompanyJsonModel : Company
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("LocationRef"), NotMapped] public string LocationReference { get; set; } = "";
}
public class UserJsonModel
    
    : User
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("NameRef"), NotMapped] public string NameReference { get; set; } = "";
    [JsonPropertyName("EmailRef"), NotMapped] public string EmailReference { get; set; } = "";
    [JsonPropertyName("LanguageRefs"), NotMapped] public string[] LanguageReferences { get; set; } = [];
    [JsonPropertyName("RoleRefs"), NotMapped] public string[] RoleReferences { get; set; } = [];
    [JsonPropertyName("TelephoneRefs"), NotMapped] public string[] TelephoneReferences { get; set; } = [];
}
