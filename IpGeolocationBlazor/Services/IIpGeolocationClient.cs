using SharedModels;

namespace IpGeolocationBlazor.Services;

public interface IIpGeolocationClient
{
    Task<IpGeolocation> GetGeolocationAsync(string ipAddress);
    Task<IpGeolocation> GetCurrentGeolocationAsync();
}