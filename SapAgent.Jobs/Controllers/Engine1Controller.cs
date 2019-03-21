using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using SapAgent.Business.Config.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.Entities.Concrete;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.Jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Engine1Controller : ControllerBase
    {
        private readonly IManager<Entities.Concrete.Pure.BackgroundProcess> _backgroundProcessManager;
        private readonly IManager<Entities.Concrete.Pure.Dump> _dumpManager;
        private readonly IManager<Entities.Concrete.Pure.Lock> _lockManager;
        private readonly IManager<Entities.Concrete.Pure.Sm51SysList> _sysListManager;
        private readonly IManager<Entities.Concrete.Pure.UserSession> _userSessionManager;
        private readonly IManager<Entities.Concrete.Pure.SystemUsage> _sysUsageManager;
        private readonly Engine2Controller _engine2Controller;
        public Engine1Controller(
            IManager<Entities.Concrete.Pure.BackgroundProcess> backgroundProcessManager,
            IManager<Entities.Concrete.Pure.Dump> dumpManager,
            IManager<Entities.Concrete.Pure.Lock> lockManager,
            IManager<Entities.Concrete.Pure.Sm51SysList> sysListManager,
            IManager<Entities.Concrete.Pure.UserSession> userSessionManager,
            IManager<Entities.Concrete.Pure.SystemUsage> sysUsageManager, Engine2Controller engine2Controller)
        {
            _backgroundProcessManager = backgroundProcessManager;
            _dumpManager = dumpManager;
            _lockManager = lockManager;
            _sysListManager = sysListManager;
            _userSessionManager = userSessionManager;
            _sysUsageManager = sysUsageManager;
            _engine2Controller = engine2Controller;
        }

        public async Task BackgroundProcessJob()
        {
            var data = await _backgroundProcessManager.Get("Agent/GetBackgroundProcessData");
            var serviceReqTime = Guid.NewGuid();
            foreach (var item in data)
            {
                item.SREQINDEX = serviceReqTime;
                _backgroundProcessManager.Add(item);
            }

            _backgroundProcessManager.UpFlag(serviceReqTime);

            _engine2Controller.BackgroundProcessJob();

        }

        public async Task DumpJobs()
        {
            var data = await _dumpManager.Get("Agent/GetCheckDumpsData");
            var serviceReqTime = Guid.NewGuid();
            foreach (var item in data)
            {
                item.SREQINDEX = serviceReqTime;
                _dumpManager.Add(item);
            }
            _dumpManager.UpFlag(serviceReqTime);

            _engine2Controller.DumpJob();
        }
        public async Task LockJobs()
        {
            var data = await _lockManager.Get("Agent/GetCheckLocksData");

            foreach (var item in data)
            {
                _lockManager.Add(item);
            }

        }
        public async Task SysListJobs()
        {
            var data = await _sysListManager.Get("/Agent/GetSystemListData");

            foreach (var item in data)
            {
                _sysListManager.Add(item);
            }

        }

        public async Task UserSessionJobs()
        {
            var data = await _userSessionManager.Get("Agent/GetUserSessionData");

            foreach (var item in data)
            {
                _userSessionManager.Add(item);
            }
        }
        public async Task SysUsageJobs()
        {
            var data = await _sysUsageManager.Get("Agent/GetSystemUsageData");

            foreach (var item in data)
            {
                _sysUsageManager.Add(item);
            }
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var jobId = BackgroundJob.Enqueue(() => BackgroundProcessJob());
            //RecurringJob.AddOrUpdate(() => BackgroundProcessJob(), Cron.Minutely);
            RecurringJob.AddOrUpdate(() => DumpJobs(), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => LockJobs(), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => SysListJobs(), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => UserSessionJobs(), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => SysUsageJobs(), Cron.Minutely);
            return Ok("Jobs Scheduled...");
        }
    }
}
