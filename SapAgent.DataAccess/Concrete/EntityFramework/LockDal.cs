using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class LockDal : BaseDal<Lock>
    {
        private new const int FunctionId = 1;
        public LockDal(IEntityRepository<Lock> entityRepository)
            : base(entityRepository, FunctionId)
        {
        }
    }
}
