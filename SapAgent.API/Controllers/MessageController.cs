using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SapAgent.API.Helper;
using SapAgent.API.Model;

namespace SapAgent.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<AlertHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<AlertHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        [Route("api/BackgroundProcessChart1")]
        public async Task<string> BackgroundProcessChart1([FromBody]BackgroundProcessNotify alert)
        {
            string retMessage;
            try
            {
                await _hubContext.Clients.All.BroadcastMessage("Background Process","Chart Updated..");
                retMessage = "Success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }
            return retMessage;
        }
    }
}