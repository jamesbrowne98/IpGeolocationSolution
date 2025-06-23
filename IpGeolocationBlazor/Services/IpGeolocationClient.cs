using System.Net.Http;
using System.Threading.Tasks;
using SharedModels;
using Serilog;

namespace IpGeolocationBlazor.Services
{
    public class IpGeolocationClient : IIpGeolocationClient
    {
        private readonly HttpClient _httpClient;

        public IpGeolocationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IpGeolocation?> GetGeolocationAsync(string ipAddress)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/IpGeolocation/{ipAddress}");
                var content = await response.Content.ReadAsStringAsync();
                Log.Information("API Response for {IpAddress}: {Content}", ipAddress, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IpGeolocation>();
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "Failed to get geolocation for {IpAddress}", ipAddress);
                return null;
            }
        }

        public async Task<IpGeolocation?> GetCurrentGeolocationAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/IpGeolocation/current");
                var content = await response.Content.ReadAsStringAsync();
                Log.Information("API Response for current: {Content}", content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IpGeolocation>();
            }
            catch (HttpRequestException ex)
            {
                Log.Error(ex, "Failed to get current geolocation");
                return null;
            }
        }
    }
}