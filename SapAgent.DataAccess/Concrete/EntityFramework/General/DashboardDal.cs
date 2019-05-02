using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class DashboardDal : BaseDal<AllNotifyCountView>
    {
        public DashboardDal(IEntityRepository<AllNotifyCountView> entityRepository) : base(entityRepository)
        {
        }
    }
}
