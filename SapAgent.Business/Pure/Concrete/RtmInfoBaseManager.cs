using System;
using System.Collections.Generic;
using System.Text;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class RtmInfoBaseManager : Manager<RtmInfoBase>, IManagerRtmInfoBase
    {
        private new const int FunctionId = 1007;
        public RtmInfoBaseManager(IBaseDal<RtmInfoBase> entityRepository, IHttpClientHelper<RtmInfoBase> httpClient, IBaseDal<FuncFlag> funcFlagBaseDal) : base(entityRepository, httpClient, FunctionId, funcFlagBaseDal)
        {

        }
    }
}
