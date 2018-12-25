using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class SysUsageDal : BaseDal<SystemUsage>
    {
        private new const int FunctionId = 1;
        public SysUsageDal(IEntityRepository<SystemUsage> entityRepository) :
            base(entityRepository, FunctionId)
        {
        }
    }
}
