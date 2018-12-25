using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class SystemFileManager : Manager<SystemFile>
    {
        private new const int FunctionId = 1;
        public SystemFileManager(IBaseDal<SystemFile> entityRepository, IHttpClientHelper<SystemFile> httpClient) : 
            base(entityRepository, httpClient, FunctionId)
        {
        }
    }
}
