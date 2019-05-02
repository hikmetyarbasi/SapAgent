using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using Lock = SapAgent.Entities.Concrete.Pure.Lock;

namespace SapAgent.Business.Pure.Concrete
{
    public class LockManager : Manager<Lock>, IManagerLock
    {
        public new static int FunctionId => 3;
        public LockManager(IBaseDal<Lock> entityRepository, IHttpClientHelper<Lock> httpClient, IBaseDal<FuncFlag> funcFlagBaseDal) :
            base(entityRepository, httpClient, FunctionId, funcFlagBaseDal)
        {
        }
    }
}
