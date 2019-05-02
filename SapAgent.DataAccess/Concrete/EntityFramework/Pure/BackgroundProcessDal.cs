using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Pure
{
    public class BackgroundProcessDal : BaseDal<Entities.Concrete.Pure.BackgroundProcess>
    {
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _funcFlagManager;
        public BackgroundProcessDal(
            IEntityRepository<Entities.Concrete.Pure.BackgroundProcess> entityRepository,            
            IBaseDal<Entities.Concrete.Config.FuncFlag> funcFlagManager) :
            base(entityRepository)
        {
            _funcFlagManager = funcFlagManager;
        }
    }
}
