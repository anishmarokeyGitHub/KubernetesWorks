using Microsoft.AspNetCore.Mvc;
using Mock.Service.API.MockService;
using Newtonsoft.Json.Linq;
namespace Mock.Service.API.Controllers;

[ApiController]
[Route("/api")]
public class MockCalcController : ControllerBase
{  
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mockTaxDocument"></param>
    /// <param name="delayInSeconds"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("SavaCalcMockData")]
    public IActionResult SavaCalcMockData([FromBody] string mockTaxDocument, int delayInSeconds = 0)
    {
        if (mockTaxDocument == null) 
        {
            return BadRequest("Invalid data.");
        }

        // Simulate saving data to static memory
        MockCalcDataStore.Data =  mockTaxDocument;
        if(delayInSeconds != 0)
        {
            TimeSpan delayTimeSpan = TimeSpan.FromSeconds(delayInSeconds);
            double milliseconds = delayTimeSpan.TotalMilliseconds;
            MockCalcDataStore.Delay = (int)milliseconds;
        }        

        return Ok("Data saved successfully.");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tomToCalculate"> As its mocking tom cal not doing anything we have to return already saved data</param>
    /// <returns></returns>
    [HttpGet]
    [Route("calc")]
    public async Task<IActionResult> GetData(string tomToCalculate)
    {
        // Simulate a delay of 2 seconds before returning the data
        await Task.Delay(MockCalcDataStore.Delay);

        // Return the data from the static memory store
        return Ok(MockCalcDataStore.Data);
    }
}
