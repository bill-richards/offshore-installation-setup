using offshore.services;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace offshore.data.parsing.models;

public class CompanyDataModel : IJsonDataModel<CompanyDataModel>
{
    public Language[] Languages { get; init; } = [];
    public Name[] Names { get; init; } = [];
    public Country[] Countries { get; init; } = [];
    public CountryCode[] CountryCodes { get; init; } = [];
    public Email[] Emails { get; init; } = [];
    public TelephoneType[] TelephoneTypes { get; init; } = [];
    public TelephoneNumber[] TelephoneNumbers { get; init; } = [];
    public Address[] Addresses { get; init; } = [];
    public Contact[] Contacts { get; init; } = [];
    public Location[] Locations { get; init; } = [];
    public Company[] Companies { get; init; } = [];
    public User[] Users { get; init; } = [];
}


public class Language : data.models.settings.Language
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
}

public class Name
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [NotMapped] public string Value { get; set; } = "";

}

public class Country : data.models.settings.Country
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
}

public class CountryCode : data.models.settings.CountryCode
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
}

public class Email
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [NotMapped] public string Value { get; set; } = "";
}
public class TelephoneType : data.models.settings.TelephoneType
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
}


public class TelephoneNumber : data.models.settings.TelephoneNumber
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("CountryCodeRef"), NotMapped] public string CountryCodeReference { get; set; } = "";
    [JsonPropertyName("TypeRef"), NotMapped] public string TypeReference { get; set; } = "";
}

public class Address : data.models.settings.Address
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("CountryRef"), NotMapped] public string CountryReference { get; set; } = "";
}

public class Contact : data.models.settings.Contact
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("NameRef"), NotMapped] public string NameReference { get; set; } = "";
    [JsonPropertyName("TelephoneRefs"), NotMapped] public string[] TelephoneReferences { get; set; } = [];

}
public class Location : data.models.settings.Location
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("AddressRef"), NotMapped] public string AddressReference { get; set; } = "";
    [JsonPropertyName("ContactRefs"), NotMapped] public string[] ContactReferences { get; set; } = [];
}
public class Company : data.models.settings.Company
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("LocationRef"), NotMapped] public string LocationReference { get; set; } = "";
}

public class User : data.models.settings.User
{
    [JsonPropertyName("Ref"), NotMapped] public string Reference { get; set; } = "";
    [JsonPropertyName("NameRef"), NotMapped] public string NameReference { get; set; } = "";
    [JsonPropertyName("EmailRef"), NotMapped] public string EmailReference { get; set; } = "";
    [JsonPropertyName("LanguageRefs"), NotMapped] public string[] LanguageReferences { get; set; } = [];
    [JsonPropertyName("RoleRefs"), NotMapped] public string[] RoleReferences { get; set; } = [];
    [JsonPropertyName("TelephoneRefs"), NotMapped] public string[] TelephoneReferences { get; set; } = [];
}
