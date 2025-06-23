namespace SharedModels;

public class IpGeolocation
{
    public string? Ip { get; set; }
    public string? Type { get; set; }
    public string? ContinentCode { get; set; }
    public string? ContinentName { get; set; }
    public string? CountryCode { get; set; }
    public string? CountryName { get; set; }
    public string? RegionCode { get; set; }
    public string? RegionName { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Msa { get; set; }
    public string? Dma { get; set; }
    public string? Radius { get; set; }
    public string? IpRoutingType { get; set; }
    public string? ConnectionType { get; set; }
    public Location? Location { get; set; }
}

public class Location
{
    public int GeonameId { get; set; }
    public string? Capital { get; set; }
    public List<Language>? Languages { get; set; }
    public string? CountryFlag { get; set; }
    public string? CountryFlagEmoji { get; set; }
    public string? CountryFlagEmojiUnicode { get; set; }
    public string? CallingCode { get; set; }
    public bool IsEu { get; set; }
}

public class Language
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? Native { get; set; }
}