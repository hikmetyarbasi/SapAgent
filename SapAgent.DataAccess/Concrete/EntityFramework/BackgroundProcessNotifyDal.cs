using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class BackgroundProcessNotifyDal : BaseDal<Entities.Concrete.Config.BackgroundProcessNotify>
    {
        private new const int FunctionId = 1;
        public BackgroundProcessNotifyDal(IEntityRepository<BackgroundProcessNotify> entityRepository) : base(entityRepository, FunctionId)
        {
        }
    }
}
