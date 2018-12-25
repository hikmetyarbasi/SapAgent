using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class SysListManager : Manager<Sm51SysList>
    {
        private new const int FunctionId = 1;
        public SysListManager(IBaseDal<Sm51SysList> entityRepository, IHttpClientHelper<Sm51SysList> httpClient)
            : base(entityRepository, httpClient, FunctionId)
        {
        }
    }
}
