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
        private readonly int _customerId = 1;
        private readonly IManagerConfig<Entities.Concrete.Config.BackgroundProcess> _backgroundProcessConfigManager;
        private readonly IManagerConfig<Entities.Concrete.Config.Dump> _dumpConfigManager;

        public Engine2Controller(IManagerConfig<Entities.Concrete.Config.BackgroundProcess> backgroundProcessManager)
        {
            _backgroundProcessConfigManager = backgroundProcessManager;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var jobId = BackgroundJob.Enqueue(() => BackgroundProcessJob());
            //RecurringJob.AddOrUpdate(() => BackgroundProcessJob(), Cron.Minutely);
            return Ok("Jobs Scheduled...");
        }

        public void BackgroundProcessJob()
        {
            try
            {
                _backgroundProcessConfigManager.StartOperation(_customerId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DumpJob()
        {
            try
            {
                _dumpConfigManager.StartOperation(_customerId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}