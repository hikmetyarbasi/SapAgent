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
    
    public class RtmInfoManager : Manager<SapAgent.Entities.Concrete.Pure.RtmInfo>, IManagerRtmInfo
    {
        private new const int FunctionId = 1007;
        public RtmInfoManager(IBaseDal<SapAgent.Entities.Concrete.Pure.RtmInfo> entityRepository, IHttpClientHelper<SapAgent.Entities.Concrete.Pure.RtmInfo> httpClient,IBaseDal<FuncFlag> funcFlagBaseDal) 
        : base(entityRepository, httpClient, FunctionId, funcFlagBaseDal)
        {

        }
    }
}
