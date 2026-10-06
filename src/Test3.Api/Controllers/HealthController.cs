using Microsoft.AspNetCore.Mvc;

namespace Test3.Api.Controllers;

/// <summary>Service health and liveness endpoints.</summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class HealthController : ControllerBase
{
    /// <summary>Returns the liveness status of the service.</summary>
    /// <returns>200 OK with a <c>{ "status": "healthy" }</c> body when the service is alive.</returns>
    /// <response code="200">Service is healthy.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get() => Ok(new { status = "healthy", timestamp = DateTime.UtcNow });
}
