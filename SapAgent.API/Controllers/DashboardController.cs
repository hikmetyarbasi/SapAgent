using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapAgent.Business.Config.Abstract;
using SapAgent.Business.General.Abstract;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.General.Dto;
using SapAgent.Entities.Concrete.Spa;
using BackgroundProcessNotify = SapAgent.Entities.Concrete.Config.BackgroundProcessNotify;

namespace SapAgent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IManagerBpConfigManager _managerBackgroundProcessConfig;
        private readonly IManagerGeneral<Entities.Concrete.General.CustomerProductView> _managerProductGeneral;
        private readonly IManagerGeneral<ClientMonitoringView> _managerClientMonitoringGeneral;

        public DashboardController(IManagerBpConfigManager managerConfig,
            IManagerGeneral<CustomerProductView> managerProductGeneral,
            IManagerGeneral<ClientMonitoringView> managerClientMonitoringGeneral)
        {
            _managerBackgroundProcessConfig = managerConfig;
            _managerProductGeneral = managerProductGeneral;
            _managerClientMonitoringGeneral = managerClientMonitoringGeneral;
        }

        [HttpGet]
        [Route("GetBackgroundProcessChart1Data")]
        public async Task<List<BpNotifyViewDto>> GetBackgroundProcessChart1Data(int customerId)
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
        public ClientMonitoringViewDto GetClientMonitroingValues(int customerProductId)
        {
            List<ClientMonitoringView> clientList = _managerClientMonitoringGeneral.GetAll(x => x.CustomerProductId == customerProductId);
            var customerProductInfo = _managerProductGeneral.GetAll(x => x.CustomerProductId == customerProductId).FirstOrDefault();
            return new ClientMonitoringViewDto()
            {
                ClientMonitoringView = clientList,
                CustomerProduct = customerProductInfo
            };
        }

    }
}