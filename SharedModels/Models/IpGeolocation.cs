using System.Text.Json.Serialization;

namespace SharedModels;

public class IpGeolocation
{
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

    [JsonPropertyName("continent_name")]
    public string? ContinentName { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    [JsonPropertyName("region_code")]
    public string? RegionCode { get; set; }

    [JsonPropertyName("region_name")]
    public string? RegionName { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("msa")]
    public string? Msa { get; set; }

    [JsonPropertyName("dma")]
    public string? Dma { get; set; }

    [JsonPropertyName("radius")]
    public string? Radius { get; set; }

    [JsonPropertyName("ip_routing_type")]
    public string? IpRoutingType { get; set; }

    [JsonPropertyName("connection_type")]
    public string? ConnectionType { get; set; }

    [JsonPropertyName("location")]
    public Location? Location { get; set; }
}

public class Location
{
    [JsonPropertyName("geoname_id")]
    public int GeonameId { get; set; }

    [JsonPropertyName("capital")]
    public string? Capital { get; set; }

    [JsonPropertyName("languages")]
    public List<Language>? Languages { get; set; }

    [JsonPropertyName("country_flag")]
    public string? CountryFlag { get; set; }

    [JsonPropertyName("country_flag_emoji")]
    public string? CountryFlagEmoji { get; set; }

    [JsonPropertyName("country_flag_emoji_unicode")]
    public string? CountryFlagEmojiUnicode { get; set; }

    [JsonPropertyName("calling_code")]
    public string? CallingCode { get; set; }

    [JsonPropertyName("is_eu")]
    public bool IsEu { get; set; }
}

public class Language
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("native")]
    public string? Native { get; set; }
}