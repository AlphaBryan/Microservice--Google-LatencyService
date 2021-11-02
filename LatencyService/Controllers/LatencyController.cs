using System.Drawing;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public List<LatencyResponse> listData = new List<LatencyResponse>() ;
        
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

                body =  "{\"servicename\": \"ServiceTEST\"}" ;
                //Call SwitchService
                JObject response  = await client.CallSwitchService(body);
                if (reponse.IsSuccessStatusCode)
                {
                    return 201 ;
                }
            }
            return 200 ; 
        }
    }
}
