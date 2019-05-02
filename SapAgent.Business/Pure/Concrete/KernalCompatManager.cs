using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class KernelCompatManager : Manager<KernelCompat>, IManagerKernelCompat
    {
        public new static int FunctionId => 8;
        public KernelCompatManager(
            IBaseDal<KernelCompat> entityRepository,
            IHttpClientHelper<KernelCompat> httpClient,
            IBaseDal<FuncFlag> funcFlagBaseDal) : base(entityRepository, httpClient, FunctionId, funcFlagBaseDal)
        {
        }
    }
}
