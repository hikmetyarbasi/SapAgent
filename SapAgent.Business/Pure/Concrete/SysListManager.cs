using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class SysListManager : Manager<SysList>, IManagerSysList
    {
        public static int FunctionId => 4;
        public SysListManager(
            IBaseDal<SysList> entityRepository,
            IHttpClientHelper<SysList> httpClient,
            IBaseDal<Entities.Concrete.Config.FuncFlag> funcFlagBaseDal)
        : base(entityRepository, httpClient, FunctionId, funcFlagBaseDal)
        {
        }
    }
}
