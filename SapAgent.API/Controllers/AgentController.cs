using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SapAgent.ExternalServices.Abstract;
using PrdSystemUsage;
using SapAgent.API.Model;
using SapAgent.Business.Pure.Abstract;
using SapAgent.Entities.Abstract;
using SapAgent.Entities.Concrete.Pure;
using SapAgent.Entities.Concrete.Spa.Dto;

namespace SapAgent.API.Controllers
{
    [EnableCors("CorsPolicy")]
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
        private readonly ISystemFileClientWrapper _systemFileClient;
        private readonly IKernelCompatClientWrapper _kernelCompatClient;
        private readonly IRtmInfoClientWrapper _rtmInfoClient;
        private readonly IMapper _mapper;

        public AgentController(IBackgroundProcessClientWrapper backProcClient,
            ICheckDumpsClientWrapper checkDumpsClient,
            IUserSessionClientWrapper userSessionClient,
            ISystemListClientWrapper systemListClient,
            ICheckLocksClientWrapper checkLocksClient,
            ISystemUsageClientWrapper systemUsageClient,
            ISystemFileClientWrapper systemFileClient,
            IKernelCompatClientWrapper kernelCompatClient,
            IMapper mapper,
            IRtmInfoClientWrapper rtmInfoClient)
        {
            _checkDumpsClient = checkDumpsClient;
            _userSessionClient = userSessionClient;
            _systemListClient = systemListClient;
            _checkLocksClient = checkLocksClient;
            _systemUsageClient = systemUsageClient;
            _backProcClient = backProcClient;
            _mapper = mapper;
            _rtmInfoClient = rtmInfoClient;
            _systemFileClient = systemFileClient;
            _kernelCompatClient = kernelCompatClient;
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
                var syslistforReturn = _mapper.Map<List<Entities.Concrete.Pure.SysList>>(syslist);
                return Ok(syslistforReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e);
            }
        }
        [HttpGet]
        [Route("GetSystemFileData")]
        public async Task<ActionResult> GetSystemFileData()
        {
            try
            {
                var sysfile = await _systemFileClient.GetData();

                var sysfileForReturn = new List<SysFile>();
                foreach (var server in sysfile)
                {
                    foreach (var item in server.TFsys)
                    {
                        var newFile = new SysFile();
                        newFile.Capacity = item.Capacity;
                        newFile.Free = item.Free;
                        newFile.FreePercent = item.FreePercent;
                        newFile.Fsysname = item.Fsysname;
                        newFile.Server = item.Server;
                        sysfileForReturn.Add(newFile);
                    }

                }
                return Ok(sysfileForReturn);
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
                var sysusage1 = _mapper.Map<List<Entities.Concrete.Pure.SysUsage>>(cpusforReturn);
                var mems = new List<CcmSnapAll>();
                foreach (var item in sysUsage)
                {
                    mems.AddRange(item.TMem);
                }
                var memsforReturn = _mapper.Map<List<Entities.Concrete.Pure.SystemUsageTmem>>(mems);
                var sysusage2 = _mapper.Map<List<Entities.Concrete.Pure.SysUsage>>(memsforReturn);
                return Ok(sysusage1.Union(sysusage2).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.InnerException?.Message);
            }
        }

        [HttpGet]
        [Route("GetKernelCompatDataAsync")]
        public async Task<ActionResult> GetKernelCompatDataAsync(int customerId)
        {
            try
            {
                var kernelData = await _kernelCompatClient.GetData();
                var kernelForReturn = _mapper.Map<KernelCompat>(kernelData);
                return Ok(kernelForReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("GetRtmInfoDataAsync")]
        public async Task<ActionResult> GetRtmInfoDataAsync()
        {

            try
            {
                var rtmForReturn = new List<RtmModel>();
                var data = await _rtmInfoClient.GetData();

                foreach (var item in data)
                {
                    var rtmInfoModel = new RtmModel()
                    {
                        RtmBase = new RtmInfoBase()
                        {
                            SERVER = item.Server,
                            STARTUPDATE = item.StartupDate,
                            STARTUPTIME = item.StartupTime
                        }
                    };
                    foreach (var info in item.TRtinfo)
                    {
                        rtmInfoModel.RtmInfos.Add(new RtmInfo()
                        {
                            ALLOCSIZE = info.AllocSize,
                            BUFFER = info.Buffer,
                            DBACCESS = info.DbAccess,
                            FREEDIR = info.FreeDir,
                            FREEDIRP = info.FreeDirP,
                            FREESIZE = info.FreeSize,
                            FREESIZEP = info.FreeSizeP,
                            HITRATIO = info.Hitratio,
                            MAXOBJCTS = info.MaxObjcts,
                            MAXSWAPPED = info.MaxSwapped,
                            NAME = info.Name
                        });
                    }
                    rtmForReturn.Add(rtmInfoModel);
                }

                return Ok(rtmForReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}