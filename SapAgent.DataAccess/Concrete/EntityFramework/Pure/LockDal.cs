using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Pure
{
    public class LockDal : BaseDal<Entities.Concrete.Pure.Lock>
    {        
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _funcFlagManager;
        public LockDal(IEntityRepository<Entities.Concrete.Pure.Lock> entityRepository,
            IBaseDal<FuncFlag> funcFlagManager)
            : base(entityRepository)
        {
            _funcFlagManager = funcFlagManager;
        }
    }
}
