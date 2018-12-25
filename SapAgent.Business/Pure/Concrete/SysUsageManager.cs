using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class SysUsageManager : Manager<SystemUsage>
    {
        private new const int FunctionId = 1;
        public SysUsageManager(IBaseDal<SystemUsage> entityRepository, IHttpClientHelper<SystemUsage> httpClient) :
            base(entityRepository, httpClient, FunctionId)
        {
        }
    }
}
