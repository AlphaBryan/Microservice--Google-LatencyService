using System.Runtime.Serialization.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

//using System.Web.Helpers;

namespace LatencyService
{

    public class LatencyClient
    {
        // private readonly HttpClient httpClient;
        static HttpClient client = new HttpClient();

        //private readonly ServiceSettings settings ; 

        // public LatencyClient(HttpClient httpClient)
        // {
        //     this.httpClient = httpClient;
        // }

        public record Route(string description);  // A revoir 
        public record Latency(Route[] route); // A revoir ??

        public async Task<dynamic> CallSwitchService(HttpContent body)
        {
            var service_response = await client.PostAsync("https://equipe08-switchservice.herokuapp.com/switchService", body);
            var service_response_string = await service_response.Content.ReadAsStringAsync();
            JObject service_response_string_js = JObject.Parse(service_response_string);
            return service_response_string_js;
        }

        public async Task<dynamic> CallGetAllServices()
        {
            var service_response = await client.PostAsync("https://eq8-log430service-discovery.herokuapp.com/getAllServices");
            var service_response_string = await service_response.Content.ReadAsStringAsync();
            JObject service_response_string_js = JObject.Parse(service_response_string);
            return service_response_string_js;
        }

    }
}