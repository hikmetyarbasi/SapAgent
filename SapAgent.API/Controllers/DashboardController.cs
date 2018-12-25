using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapAgent.Business.Config.Abstract;
using SapAgent.Business.General.Abstract;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IManagerConfig<Entities.Concrete.Config.BackgroundProcess> _managerBackgroundProcessConfig;
        private readonly IManagerGeneral<Entities.Concrete.General.CustomerProductView> _managerProductGeneral;

        public DashboardController(IManagerConfig<Entities.Concrete.Config.BackgroundProcess> managerConfig, IManagerGeneral<CustomerProductView> managerProductGeneral)
        {
            _managerBackgroundProcessConfig = managerConfig;
            _managerProductGeneral = managerProductGeneral;
        }

        [HttpGet]
        [Route("GetBackgroundProcessChart1Data")]
        public List<BpNotifyView> GetBackgroundProcessChart1Data(int customerId)
        {
            return _managerBackgroundProcessConfig.GetCurrentStateOfNotify();
        }

        [HttpGet]
        [Route("GetBackgroundProcessTotalJobCount")]
        public int GetBackgroundProcessTotalJobCount(int customerId)
        {
            return _managerBackgroundProcessConfig.GetBackgroundProcessTotalJobCount();
        }

        [HttpGet]
        [Route("GetProducts")]
        public List<CustomerProductView> GetProducts(int customerId)
        {
            return _managerProductGeneral.GetAll(x => x.CustomerId == customerId);
        }
    }
}