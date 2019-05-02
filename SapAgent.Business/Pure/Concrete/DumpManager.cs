using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using Dump = SapAgent.Entities.Concrete.Pure.Dump;

namespace SapAgent.Business.Pure.Concrete
{
    public class DumpManager : Manager<Dump>, IManagerDump
    {
        public new static int FunctionId => 2;


        public DumpManager(IBaseDal<Dump> entityRepository,
            IHttpClientHelper<Dump> httpClient,
            IBaseDal<FuncFlag> funcFlagBaseDal)
        : base(entityRepository, httpClient, FunctionId, funcFlagBaseDal)
        {

        }

    }
}
