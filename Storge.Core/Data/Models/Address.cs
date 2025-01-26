namespace Storge.Core.Data.Models;

public class Address(string street, string city, string country, string postalCode, string? region = null)
{
    public string Street { get; set; } = street;
    public string City { get; set; } = city;
    public string Country { get; set; } = country;
    public string PostalCode { get; set; } = postalCode;

    public string? Region { get; set; } = region;
}