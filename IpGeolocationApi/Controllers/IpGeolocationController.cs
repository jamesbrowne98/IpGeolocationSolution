using Microsoft.AspNetCore.Mvc;
using IpGeolocationApi.Services;
using SharedModels;

namespace IpGeolocationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IpGeolocationController : ControllerBase
{
    private readonly IIpGeolocationService _service;

    public IpGeolocationController(IIpGeolocationService service)
    {
        _service = service;
    }

    [HttpGet("{ipAddress}")]
    public async Task<ActionResult<IpGeolocation>> Get(string ipAddress)
    {
        try
        {
            var result = await _service.GetGeolocationAsync(ipAddress);
            if (result == null)
                return NotFound("Could not retrieve geolocation data.");
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

    [HttpGet("current")]
    public async Task<ActionResult<IpGeolocation>> GetCurrent()
    {
        try
        {
            var result = await _service.GetCurrentGeolocationAsync();
            if (result == null)
                return NotFound("Could not retrieve geolocation data.");
            return Ok(result);
        }
        catch (Exception)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }
}