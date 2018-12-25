using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class LockManager : Manager<Lock>
    {
        private new const int FunctionId = 1;
        public LockManager(IBaseDal<Lock> entityRepository, IHttpClientHelper<Lock> httpClient)
            : base(entityRepository, httpClient, FunctionId)
        {
        }
    }
}
