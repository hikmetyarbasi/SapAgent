using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;
using Dump = SapAgent.Entities.Concrete.Pure.Dump;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Pure
{
    public class DumpDal : BaseDal<Dump>
    {
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _funcFlagManager;
        public DumpDal(IEntityRepository<Dump> entityRepository, IBaseDal<FuncFlag> funcFlagManager)
            : base(entityRepository)
        {
            _funcFlagManager = funcFlagManager;
        }
      
    }
}
