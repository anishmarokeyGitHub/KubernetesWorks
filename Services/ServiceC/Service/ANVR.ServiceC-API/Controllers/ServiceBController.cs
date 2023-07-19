using Microsoft.AspNetCore.Mvc;

namespace ANVR.ServiceC_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceBController : ControllerBase
{
    [HttpGet]
    [Route("IsHealthy")]
    public string IsHealthy()=> "Service c is healthy";
}