using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class SysListDal : BaseDal<SysList>
    {        
        public SysListDal(IEntityRepository<SysList> entityRepository)
            : base(entityRepository)
        {
        }
    }
}
