using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class UserSessionManager : Manager<UserSession>, IManagerUserSession
    {
        public static int FunctionId => 5;
        public UserSessionManager(IBaseDal<UserSession> entityRepository, IHttpClientHelper<UserSession> httpClient, IBaseDal<FuncFlag> funcBaseDal)
            : base(entityRepository, httpClient, FunctionId, funcBaseDal)
        {
        }
    }
}
