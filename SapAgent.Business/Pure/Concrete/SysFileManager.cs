using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Concrete
{
    public class SysFileManager : Manager<SysFile>,IManagerSysFile
    {

        private new const int FunctionId = 7;
        public SysFileManager(IBaseDal<SysFile> entityRepository,
            IHttpClientHelper<SysFile> httpClient,
            IBaseDal<Entities.Concrete.Config.FuncFlag> funcFlagBaseDal) :
            base(entityRepository, httpClient, FunctionId, funcFlagBaseDal)
        {
        }
    }
}
