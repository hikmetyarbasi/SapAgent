using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class NotificationDal:BaseDal<BackgroundProcessNotify>
    {
        private new const int FunctionId = 1;
        public NotificationDal(IEntityRepository<BackgroundProcessNotify> entityRepository) 
            : base(entityRepository, FunctionId)
        {
        }
    }
}
