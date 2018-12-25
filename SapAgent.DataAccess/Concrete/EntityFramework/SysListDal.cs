using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class SysListDal : BaseDal<Sm51SysList>
    {
        private new const int FunctionId = 1;
        public SysListDal(IEntityRepository<Sm51SysList> entityRepository)
            : base(entityRepository, FunctionId)
        {
        }
    }
}
