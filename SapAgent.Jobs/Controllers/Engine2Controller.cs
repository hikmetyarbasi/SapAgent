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
        private int productId = 1;
        private readonly IManagerConfigBpManager _backgroundProcessConfigManager;
        private readonly IManagerConfigDmpManager _dumpConfigManager;
        private readonly IManagerConfigLockManager _configLockManager;
        private readonly IManagerConfigSysUsageManager _configSysUsageManager;
        private readonly IManagerConfigSysListManager _configSysListManager;
        private readonly IManagerConfigSysFileManager _configSysFileManager;

        public Engine2Controller(IManagerConfigBpManager backgroundProcessManager, IManagerConfigDmpManager dumpConfigManager, IManagerConfigLockManager configLockManager, IManagerConfigSysUsageManager configSysUsageManager, IManagerConfigSysListManager configSysListManager, IManagerConfigSysFileManager configSysFileManager)
        {
            _backgroundProcessConfigManager = backgroundProcessManager;
            _dumpConfigManager = dumpConfigManager;
            _configLockManager = configLockManager;
            _configSysUsageManager = configSysUsageManager;
            _configSysListManager = configSysListManager;
            _configSysFileManager = configSysFileManager;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //var jobId = BackgroundJob.Enqueue(() => BackgroundProcessJob());
            //RecurringJob.AddOrUpdate(() => BackgroundProcessJob(), Cron.Minutely);
            //RecurringJob.AddOrUpdate(() => LockJob(), Cron.Minutely);
            return Ok("Jobs Scheduled...");
        }

        public void BackgroundProcessJob()
        {
            try
            {
                _backgroundProcessConfigManager.StartOperation(_customerId, productId);
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
                _dumpConfigManager.StartOperation(_customerId, productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void LockJob()
        {
            try
            {
                _configLockManager.StartOperation(_customerId, productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SysUsage()
        {
            try
            {
                _configSysUsageManager.StartOperation(_customerId, productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void SysList()
        {
            try
            {
                _configSysListManager.StartOperation(_customerId, productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void SysFile()
        {
            try
            {
                _configSysFileManager.StartOperation(_customerId,productId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}