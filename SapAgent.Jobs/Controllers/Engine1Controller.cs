using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private readonly IManagerBackgroundProcess _backgroundProcessManager;
        private readonly IManagerDump _dumpManager;
        private readonly IManagerLock _lockManager;
        private readonly IManagerSysList _sysListManager;
        private readonly IManagerSysFile _sysFileManager;
        private readonly IManagerUserSession _userSessionManager;
        private readonly IManagerSysUsage _sysUsageManager;
        private readonly Engine2Controller _engine2Controller;
        public Engine1Controller(
            IManagerBackgroundProcess backgroundProcessManager,
            IManagerDump dumpManager,
            IManagerLock lockManager,
            IManagerSysList sysListManager,
            IManagerUserSession userSessionManager,
            IManagerSysUsage sysUsageManager,
            Engine2Controller engine2Controller,
            IManagerSysFile sysFileManager)
        {
            _backgroundProcessManager = backgroundProcessManager;
            _dumpManager = dumpManager;
            _lockManager = lockManager;
            _sysListManager = sysListManager;
            _userSessionManager = userSessionManager;
            _sysUsageManager = sysUsageManager;
            _engine2Controller = engine2Controller;
            _sysFileManager = sysFileManager;
        }

        public async Task BackgroundProcessJob(int customerId, int productId)
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

        public async Task DumpJobs(int customerId, int productId)
        {
            var data = await _dumpManager.Get("Agent/GetCheckDumpsData");
            var serviceReqTime = Guid.NewGuid();
            foreach (var item in data)
            {
                item.CustomerId = customerId;
                item.ProductId = productId;
                item.SREQINDEX = serviceReqTime;
                var record = _dumpManager.GetAll(x => x.TID == item.TID).FirstOrDefault();
                if (record == null)
                {
                    _dumpManager.Add(item);
                }
                else
                {
                    record.SREQINDEX = serviceReqTime;
                    _dumpManager.Update(record);
                }
            }
            _dumpManager.UpFlag(serviceReqTime);

            _engine2Controller.DumpJob();
        }
        public async Task LockJobs(int customerId, int productId)
        {
            var data = await _lockManager.Get("Agent/GetCheckLocksData");
            var serviceReqTime = Guid.NewGuid();
            foreach (var item in data)
            {
                item.SREQINDEX = serviceReqTime;
                _lockManager.Add(item);
            }
            _lockManager.UpFlag(serviceReqTime);

            _engine2Controller.LockJob();

        }
        public async Task SysListJobs(int customerId, int productId)
        {
            var data = await _sysListManager.Get("Agent/GetSystemListData");
            var serviceReqTime = Guid.NewGuid();
            foreach (var item in data)
            {
                item.CustomerId = customerId;
                item.ProductId = productId;
                item.SREQINDEX = serviceReqTime;
                _sysListManager.Add(item);
            }
            _sysListManager.UpFlag(serviceReqTime);

            _engine2Controller.SysList();
        }

        public async Task UserSessionJobs(int customerId, int productId)
        {
            var data = await _userSessionManager.Get("Agent/GetUserSessionData");

            foreach (var item in data)
            {
                _userSessionManager.Add(item);
            }
        }
        public async Task SysUsageJobs(int customerId, int productId)
        {
            var data = await _sysUsageManager.Get("Agent/GetSystemUsageData");
            var serviceReqTime = Guid.NewGuid();
            foreach (var item in data)
            {
                item.CustomerId = customerId;
                item.ProductId = productId;
                item.SREQINDEX = serviceReqTime;
                _sysUsageManager.Add(item);
            }
            _sysUsageManager.UpFlag(serviceReqTime);

            _engine2Controller.SysUsage();
        }
        public async Task SysFileJobs(int customerId, int productId)
        {
            var data = await _sysFileManager.Get("Agent/GetSystemFileData");
            var serviceReqTime = Guid.NewGuid();

            //_sysFileManager.DownFlag();
            foreach (var item in data)
            {
                item.CustomerId = customerId;
                item.ProductId = productId;
                item.SREQINDEX = serviceReqTime;
                _sysFileManager.Add(item);
            }
            _sysFileManager.UpFlag(serviceReqTime);

            _engine2Controller.SysFile();
        }

        public async Task LockDailyAverage()
        {
            _backgroundProcessManager.ExecuteSqlQuery("PROC_CALCCOUNT_LOCKDAILY");
        }
        public async Task DumpSetErrorIdAverage()
        {
            _dumpManager.ExecuteSqlQuery("PROC_CALCCOUNT_DUMPDAILY");
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //BackgroundJob.Enqueue(() => DumpJobs(1, 1));
            //RecurringJob.AddOrUpdate(() => BackgroundProcessJob(), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => DumpJobs(1, 1), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => LockJobs(), Cron.Minutely);

            //RecurringJob.AddOrUpdate(() => SysListJobs(1, 1), Cron.Minutely);
            RecurringJob.AddOrUpdate(() => SysFileJobs(1, 1), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => UserSessionJobs(), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => SysUsageJobs(1, 1), Cron.Minutely);
            return Ok("Jobs Scheduled...");
        }
    }
}
