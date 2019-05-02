using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Pure;
using SysUsage = SapAgent.Entities.Concrete.Pure.SysUsage;

namespace SapAgent.Business.Pure.Concrete
{
    public class SysUsageManager : Manager<SysUsage>, IManagerSysUsage
    {
        public static int FunctionId => 6;
        public SysUsageManager(IBaseDal<SysUsage> entityRepository,
            IHttpClientHelper<SysUsage> httpClient, 
            IBaseDal<FuncFlag> funcBaseDal)
        : base(entityRepository, httpClient, FunctionId, funcBaseDal)
        {
        }
    }
}
