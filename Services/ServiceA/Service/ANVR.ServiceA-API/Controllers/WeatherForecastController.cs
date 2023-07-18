using Microsoft.AspNetCore.Mvc;

namespace ANVR.ServiceA_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceAController : ControllerBase
{


    [HttpGet]
    [Route("IsHealthy")]
    public string IsHealthy()=> "Service A is healthy";
}