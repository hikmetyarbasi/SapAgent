using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapAgent.ExternalServices.Abstract;
using PrdSystemUsage;

namespace SapAgent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IBackgroundProcessClientWrapper _backProcClient;
        private readonly ICheckDumpsClientWrapper _checkDumpsClient;
        private readonly IUserSessionClientWrapper _userSessionClient;
        private readonly ISystemListClientWrapper _systemListClient;
        private readonly ICheckLocksClientWrapper _checkLocksClient;
        private readonly ISystemUsageClientWrapper _systemUsageClient;
        private readonly IMapper _mapper;

        public AgentController(IBackgroundProcessClientWrapper backProcClient,
            ICheckDumpsClientWrapper checkDumpsClient,
            IUserSessionClientWrapper userSessionClient,
            ISystemListClientWrapper systemListClient,
            ICheckLocksClientWrapper checkLocksClient,
            ISystemUsageClientWrapper systemUsageClient,
            IMapper mapper)
        {
            _checkDumpsClient = checkDumpsClient;
            _userSessionClient = userSessionClient;
            _systemListClient = systemListClient;
            _checkLocksClient = checkLocksClient;
            _systemUsageClient = systemUsageClient;
            _backProcClient = backProcClient;
            _mapper = mapper;

        }

        [HttpGet]
        [Route("GetBackgroundProcessData")]
        public async Task<ActionResult> GetBackgroundProcessData()
        {
            try
            {
                var backprocs = await _backProcClient.GetData();
                var backprocsforReturn = _mapper.Map<List<Entities.Concrete.Pure.BackgroundProcess>>(backprocs);
                return Ok(backprocsforReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("GetCheckDumpsData")]
        public async Task<ActionResult> GetCheckDumpsData()
        {
            try
            {
                var dumps = await _checkDumpsClient.GetData();
                var dumpsforReturn = _mapper.Map<List<Entities.Concrete.Pure.Dump>>(dumps);
                return Ok(dumpsforReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetCheckLocksData")]
        public async Task<ActionResult> GetCheckLocksData()
        {
            try
            {
                var locks = await _checkLocksClient.GetData();
                var locksforReturn = _mapper.Map<List<Entities.Concrete.Pure.Lock>>(locks);
                return Ok(locksforReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("GetSystemListData")]
        public async Task<ActionResult> GetSystemListData()
        {
            try
            {
                var syslist = await _systemListClient.GetData();
                var syslistforReturn = _mapper.Map<List<Entities.Concrete.Pure.Sm51SysList>>(syslist);
                return Ok(syslistforReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Route("GetUserSessionData")]
        public async Task<ActionResult> GetUserSessionData()
        {
            try
            {
                var usersession = await _userSessionClient.GetData();
                var userSessionListforReturn = _mapper.Map<List<Entities.Concrete.Pure.UserSession>>(usersession);
                return Ok(userSessionListforReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.InnerException?.Message);
            }
        }
        [HttpGet]
        [Route("GetSystemUsageData")]
        public async Task<ActionResult> GetSystemUsageData()
        {
            try
            {
                var sysUsage = await _systemUsageClient.GetData();
                var cpus = new List<CcmSnapAll>();
                foreach (var item in sysUsage)
                {
                    cpus.AddRange(item.TCpu);
                }

                var cpusforReturn = _mapper.Map<List<Entities.Concrete.Pure.SystemUsageTcpu>>(cpus);
                var sysusage1 = _mapper.Map<List<Entities.Concrete.Pure.SystemUsage>>(cpusforReturn);
                var mems = new List<CcmSnapAll>();
                foreach (var item in sysUsage)
                {
                    mems.AddRange(item.TMem);
                }
                var memsforReturn = _mapper.Map<List<Entities.Concrete.Pure.SystemUsageTmem>>(mems);
                var sysusage2 = _mapper.Map<List<Entities.Concrete.Pure.SystemUsage>>(memsforReturn);
                return Ok(sysusage1.Union(sysusage2).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.InnerException?.Message);
            }
        }
    }
}