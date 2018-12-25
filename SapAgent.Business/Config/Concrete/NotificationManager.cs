using Helpers.Abstract;
using SapAgent.Business.Pure.Concrete;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.Business.Config.Concrete
{
    class NotificationManager:ManagerConfig<BackgroundProcessNotify>
    {
        public NotificationManager(IBaseDal<BackgroundProcessNotify> entityRepository) :
            base(entityRepository)
        {

        }
    }
}
