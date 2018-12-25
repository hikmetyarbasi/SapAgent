using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class DumpManager : Manager<Dump>
    {
        public new const int FunctionId = 1;
        public DumpManager(IBaseDal<Dump> entityRepository, IHttpClientHelper<Dump> httpClient)
            : base(entityRepository, httpClient, FunctionId)
        {
        }
    }
}
