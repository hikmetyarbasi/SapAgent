using System;
using System.Collections.Generic;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using SapAgent.Business.Config.Abstract;

namespace SapAgent.Jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Engine2Controller : ControllerBase
    {
        private readonly IManagerConfig<Entities.Concrete.Config.BackgroundProcess> _backgroundProcessManager;

        public Engine2Controller(IManagerConfig<Entities.Concrete.Config.BackgroundProcess> backgroundProcessManager)
        {
            _backgroundProcessManager = backgroundProcessManager;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var jobId = BackgroundJob.Enqueue(() => BackgroundProcessJob());
            RecurringJob.AddOrUpdate(() => BackgroundProcessJob(), Cron.Minutely);
            return Ok("Jobs Scheduled...");
        }

        public void BackgroundProcessJob()
        {
            try
            {
                _backgroundProcessManager.StartOperation();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}