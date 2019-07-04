using System;
using System.Collections.Generic;
using System.Text;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Spa.Dto;

namespace SapAgent.Business.Pure.Concrete
{
    public class RtmModelManager:Manager<RtmModel>,IManagerRtmModel
    {
        private new const int FunctionId = 1007;
        public RtmModelManager(IBaseDal<RtmModel> entityRepository, IHttpClientHelper<RtmModel> httpClient,IBaseDal<FuncFlag> funcFlagBaseDal) 
            : base(entityRepository, httpClient, FunctionId, funcFlagBaseDal)
        {
        }
    }
}
