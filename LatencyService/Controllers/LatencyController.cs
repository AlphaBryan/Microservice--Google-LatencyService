using System.Drawing;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http ; 
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
        private readonly LatencyClient client ;
        //Liste qui contient toutes les datas
        
        public int maxLatency = 15000 ; //MILLISECONDE ?


        public LatencyController(ILogger<LatencyController> logger, LatencyClient client)
        {
            _logger = logger;
            this.client = client ; 
        } 

        [HttpGet]
        [Route("/heartcheck")]
        public async Task<int> ping (int time)
        {
            if (time > maxLatency){

                var body =  "{\"servicename\": \"ServiceTEST\"}" ;

                var stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                //Call SwitchService
                var response  = await client.CallSwitchService(stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return 200;
                }
            }
            return 500; 
        }
    }
}
