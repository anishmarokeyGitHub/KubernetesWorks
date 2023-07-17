using Microsoft.AspNetCore.Mvc;

namespace ANVR.ServiceB_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceBController : ControllerBase
{
    [HttpGet]
    [Route("IsHealthy")]
    public string IsHealthy()=> "Service B is healthy";
}
