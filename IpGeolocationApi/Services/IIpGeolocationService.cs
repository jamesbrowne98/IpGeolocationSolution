using SharedModels;

namespace IpGeolocationApi.Services;

public interface IIpGeolocationService
{
    Task<IpGeolocation> GetGeolocationAsync(string ipAddress);
    Task<IpGeolocation> GetCurrentGeolocationAsync();
}