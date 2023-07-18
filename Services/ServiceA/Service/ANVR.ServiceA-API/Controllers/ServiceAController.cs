using Microsoft.AspNetCore.Mvc;

namespace ANVR.ServiceA_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceAController : ControllerBase
{
    #region Private Variables
    private readonly IHttpClientFactory _httpClientFactory;
    #endregion

    #region Constructor
    public ServiceAController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    #endregion
 
    #region Endpoints

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("IsHealthy")]
    public string IsHealthy()=> "Service A is healthy";

    [HttpGet]
    [Route("GetApiData")]
    public async Task<IActionResult> GetApiData([FromQuery] string apiUrl)
    {           
        HttpClient httpClient = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
        // Ensure the response is successful
        response.EnsureSuccessStatusCode();
        // Read the response content as a string
        string content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        
    }
    #endregion
}
