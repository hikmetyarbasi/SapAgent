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
    public class BackgroundProcessManager : Manager<BackgroundProcess>, IManagerBackgroundProcess
    {
        public new static int FunctionId => 1;
        public BackgroundProcessManager(
            IHttpClientHelper<Entities.Concrete.Pure.BackgroundProcess> httpClient,
            IBaseDal<Entities.Concrete.Config.FuncFlag> funcFlagManager,
            IBaseDal<BackgroundProcess> bpBaseDal) : base(bpBaseDal, httpClient, FunctionId, funcFlagManager)
        {
        }
    }
}
