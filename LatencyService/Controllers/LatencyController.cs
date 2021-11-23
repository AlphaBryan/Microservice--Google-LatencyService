using System.Drawing;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LatencyService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LatencyController : ControllerBase
    {
        private readonly ILogger<LatencyController> _logger;
        private readonly LatencyClient latencyClient = new LatencyClient();
        static HttpClient client = new HttpClient();

        //Liste qui contient toutes les datas

        public int maxLatency = 15000;

        [HttpPost]
        [Route("/heartcheck")]
        public async Task<int> ping([FromBody] int time)
        {
            if (time > maxLatency)
            {
                var body = "{\"servicename\": \"intersection\"}";
                //  if (lane crash) {
                //      getAllServices --> "lane"
                //          host : https
                // }

                var stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await latencyClient.CallSwitchService(stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return 200;
                }
            }
            return 500;
        }
    }
}
