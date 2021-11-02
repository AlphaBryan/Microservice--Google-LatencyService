using System.Runtime.Serialization.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

//using System.Web.Helpers;

namespace LatencyService {

    public class LatencyClient
    {
        private readonly HttpClient httpClient ;

        private readonly ServiceSettings settings ; 

        public LatencyClient(HttpClient httpClient, IOptions<ServiceSettings> options )
        {
            this.httpClient = httpClient ; 
            settings = options.Value ;
        }

        public record Route (string description) ;  // A revoir 
        public record Latency(Route[] route ) ; // A revoir ??

        

          public async Task<dynamic> CreateLatency(string url_Service )
        {
            var service_response = await httpClient.GetAsync( url_Service ) ; 
            var service_response_string = await service_response.Content.ReadAsStringAsync() ; 
            Thread.Sleep( 15000 );
            JObject service_response_string_js = JObject.Parse(service_response_string);
            return service_response_string_js ; 
        }

        public async Task<dynamic> CallSwitchService(string body)
        {   
            var service_response = await client.PostAsync( "https://equipe08-switchservice.herokuapp.com/switchService}" , body);
            var service_response_string = await service_response.Content.ReadAsStringAsync() ; 
            JObject service_response_string_js = JObject.Parse(service_response_string);
            return service_response_string_js ; 
        }
        
    }
}