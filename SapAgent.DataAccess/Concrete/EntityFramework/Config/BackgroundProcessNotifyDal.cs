using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class BackgroundProcessNotifyDal : BaseDal<Entities.Concrete.Config.BackgroundProcessNotify>
    {
        public BackgroundProcessNotifyDal(IEntityRepository<BackgroundProcessNotify> entityRepository) : base(entityRepository)
        {
        }
    }
}
