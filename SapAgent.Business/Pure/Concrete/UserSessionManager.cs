using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class UserSessionManager : Manager<UserSession>
    {
        private new const int FunctionId = 1;
        public UserSessionManager(IBaseDal<UserSession> entityRepository, IHttpClientHelper<UserSession> httpClient)
            : base(entityRepository, httpClient, FunctionId)
        {
        }
    }
}
