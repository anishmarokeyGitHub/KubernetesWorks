using Newtonsoft.Json.Linq;
namespace Mock.Service.API.MockService;

/// <summary>
/// Store mock data
/// </summary>
public class MockCalcDataStore
{
    /// <summary>
    /// if needed you can configure delay. which is used in get
    /// </summary>
    /// <value></value>
    public static int Delay {get;set;}
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="string"></typeparam>
    /// <returns></returns>
    public static string Data { get; set; } 
}

