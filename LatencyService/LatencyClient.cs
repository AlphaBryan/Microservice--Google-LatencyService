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

        //private readonly ServiceSettings settings ; 

        public LatencyClient(HttpClient httpClient )
        {
            this.httpClient = httpClient ; 
        }

        public record Route (string description) ;  // A revoir 
        public record Latency(Route[] route ) ; // A revoir ??

        public async Task<dynamic> CallSwitchService(HttpContent body)
        {   
            var service_response = await httpClient.PostAsync( "https://equipe08-switchservice.herokuapp.com/switchService}" , body);
            var service_response_string = await service_response.Content.ReadAsStringAsync(); 
            JObject service_response_string_js = JObject.Parse(service_response_string);
            return service_response_string_js; 
        }
        
    }
}