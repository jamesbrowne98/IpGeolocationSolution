using Microsoft.Extensions.Options;
using SharedModels;
using System.Text.Json;
using IpGeolocationApi.Settings;
using Serilog;

namespace IpGeolocationApi.Services;

public class IpGeolocationService : IIpGeolocationService
{
    private readonly HttpClient _httpClient;
    private readonly IpstackSettings _settings;
    private readonly JsonSerializerOptions _jsonOptions;

    public IpGeolocationService(HttpClient httpClient, IOptions<IpstackSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true
        };
    }

    public async Task<IpGeolocation?> GetGeolocationAsync(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress))
            throw new ArgumentException("IP address cannot be empty.");

        var url = $"https://api.ipstack.com/{ipAddress}?access_key={_settings.ApiKey}";
        try
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            Log.Information("ipstack API Response for {IpAddress}: {Content}", ipAddress, content);
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<IpGeolocation>(content, _jsonOptions);
            if (result == null)
            {
                Log.Warning("Failed to deserialize ipstack response for {IpAddress}", ipAddress);
                return null;
            }
            return result;
        }
        catch (HttpRequestException ex)
        {
            Log.Error(ex, "Failed to call ipstack API for {IpAddress}", ipAddress);
            return null;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unexpected error in GetGeolocationAsync for {IpAddress}", ipAddress);
            return null;
        }
    }

    public async Task<IpGeolocation?> GetCurrentGeolocationAsync()
    {
        var url = $"https://api.ipstack.com/check?access_key={_settings.ApiKey}";
        try
        {
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            Log.Information("ipstack API Response for current: {Content}", content);
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<IpGeolocation>(content, _jsonOptions);
            if (result == null)
            {
                Log.Warning("Failed to deserialize ipstack response for current");
                return null;
            }
            return result;
        }
        catch (HttpRequestException ex)
        {
            Log.Error(ex, "Failed to call ipstack API for current");
            return null;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Unexpected error in GetCurrentGeolocationAsync");
            return null;
        }
    }
}