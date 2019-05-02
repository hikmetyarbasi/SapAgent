using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SapAgent.Business.Config.Abstract;
using SapAgent.Business.General.Abstract;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.Dto;
using SapAgent.Entities.Concrete.General.@enum;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IManagerGeneralDashboard _managerGeneralDashboard;
        private readonly IManagerConfigBpManager _managerBackgroundProcessConfig;
        private readonly IManagerGeneralCustomerProduct _managerProductGeneral;
        private readonly IManagerGeneralClientMonitoring _managerClientMonitoringGeneral;
        private readonly IManagerConfigLockManager _managerLockConfig;
        private readonly IManagerConfigDmpManager _managerDumpConfig;
        private readonly IManagerConfigSysUsageManager _managerSysUsageConfig;
        private readonly IManagerConfigSysListManager _managerSysListConfig;
        private readonly IManagerConfigSysFileManager _managerSysFileConfig;

        public DashboardController(IManagerConfigBpManager managerConfig,
            IManagerGeneralCustomerProduct managerProductGeneral,
            IManagerGeneralClientMonitoring managerClientMonitoringGeneral,
            IManagerGeneralDashboard managerGeneralDashboard,
            IManagerConfigLockManager managerLockConfig,
            IManagerConfigDmpManager managerDumpConfig,
            IManagerConfigSysUsageManager managerSysUsageConfig, IManagerConfigSysListManager managerSysListConfig,
            IManagerConfigSysFileManager managerSysFileConfig)
        {
            _managerBackgroundProcessConfig = managerConfig;
            _managerProductGeneral = managerProductGeneral;
            _managerClientMonitoringGeneral = managerClientMonitoringGeneral;
            _managerGeneralDashboard = managerGeneralDashboard;
            _managerLockConfig = managerLockConfig;
            _managerDumpConfig = managerDumpConfig;
            _managerSysUsageConfig = managerSysUsageConfig;
            _managerSysListConfig = managerSysListConfig;
            _managerSysFileConfig = managerSysFileConfig;
        }

        [HttpGet]
        [Route("GetDasboardMonitoringState")]
        public async Task<List<AllNotifyCountViewDto>> GetDasboardMonitoringState(int customerId)
        {
            return await _managerBackgroundProcessConfig.GetCurrentStateOfNotify(customerId);
        }

        [HttpGet]
        [Route("GetBackgroundProcessTotalJobCount")]
        public int GetBackgroundProcessTotalJobCount(int customerId)
        {
            return _managerBackgroundProcessConfig.GetBackgroundProcessTotalJobCount();
        }

        [HttpGet]
        [Route("GetProducts")]
        public List<Product> GetProducts(int customerId)
        {
            return _managerProductGeneral.GetProducts(customerId);
        }
        [HttpGet]
        [Route("GetClientMonitoringValue")]
        public ClientMonitoringViewDto GetClientMonitoringValue(int customerProductId)
        {
            List<ClientMonitoringView> clientList = _managerClientMonitoringGeneral.GetAll(x => x.CustomerProductId == customerProductId && x.Level == (int)Level.error).Result;
            var customerProductInfo = _managerProductGeneral.GetAll(x => x.CustomerProductId == customerProductId).Result.FirstOrDefault();
            return new ClientMonitoringViewDto()
            {
                ClientMonitoringView = clientList,
                CustomerProduct = customerProductInfo
            };
        }
        [HttpGet]
        [Route("GetBpNotifyDetailAsync")]
        public async Task<List<BpNotifyDetailView>> GetBpNotifyDetailAsync(int customerProductId)
        {
            return await _managerBackgroundProcessConfig.GetBpNotifyDetail(customerProductId);
        }

        [HttpGet]
        [Route("GetLockNotifyDetailAsync")]
        public async Task<List<LockNotifyDetailView>> GetLockNotifyDetailAsync(int customerProductId)
        {
            return await _managerLockConfig.GetLockNotifyDetail(customerProductId);
        }
        [HttpGet]
        [Route("GetDumpNotifyDetailAsync")]
        public async Task<List<DumpNotifyDetailView>> GetDumpNotifyDetailAsync(int customerProductId)
        {
            return await _managerDumpConfig.GetDmpNotifyDetail(customerProductId);
        }
        [HttpGet]
        [Route("GetSysUsageNotifyDetailAsync")]
        public async Task<List<SysUsageNotifyDetailView>> GetSysUsageNotifyDetailAsync(int customerProductId)
        {
            return await _managerSysUsageConfig.GetSysUsageNotifyDetail(customerProductId);
        }
        [HttpGet]
        [Route("GetSysListNotifyDetailAsync")]
        public async Task<List<SysListNotifyDetailView>> GetSysListNotifyDetailAsync(int customerProductId)
        {
            return await _managerSysListConfig.GetSysListNotifyDetail(customerProductId);
        }
        [HttpGet]
        [Route("GetSysFileNotifyDetailAsync")]
        public async Task<List<SysFileNotifyDetailView>> GetSysFileNotifyDetailAsync(int customerProductId)
        {
            return await _managerSysFileConfig.GetSysFileNotifyDetail(customerProductId);
        }
    }
}