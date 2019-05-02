using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PrdCheckDumps;
using PrdCheckLocks;
using PrdSystemList;
using PrdSystemUsage;
using PrdBackgroundProcess;
using PrdKernalCompat;
using PrdSystemFile;
using SapAgent.Entities.Concrete;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.API.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ZaygbssysTbtcjobBkRfChar, Entities.Concrete.Pure.BackgroundProcess>();
            CreateMap<ZaygbcsysRdumpov, Entities.Concrete.Pure.Dump>();
            CreateMap<ZaygbcsysLocksRf, Entities.Concrete.Pure.Lock>();
            CreateMap<ZaygbcsysMsxxlistV6Rf, Entities.Concrete.Pure.SysList>();
            CreateMap<CcmFsysSingle, Entities.Concrete.Pure.SysFile>();
            CreateMap<ZaygbcsysKernelstatRf, Entities.Concrete.Pure.KernelCompat>();

            CreateMap<UserSession.ZaygbssysUsersessRf, Entities.Concrete.Pure.UserSession>();
            CreateMap<CcmSnapAll, Entities.Concrete.Pure.SystemUsageTcpu>().ForMember<string>(dest=>dest.TYPE, opt =>
            {
                opt.MapFrom(x=>"Cpu");
            });
            CreateMap<CcmSnapAll, Entities.Concrete.Pure.SystemUsageTmem>().ForMember<string>(dest => dest.TYPE, opt =>
            {
                opt.MapFrom(x => "Mem");
            });
            CreateMap<SystemUsageTmem, Entities.Concrete.Pure.SysUsage>();
            CreateMap<SystemUsageTcpu, Entities.Concrete.Pure.SysUsage>();
        }
    }
}
