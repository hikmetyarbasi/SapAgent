using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Config
{
    public class SchedulerDal : BaseDal<Scheduler>
    {
        public SchedulerDal(IEntityRepository<Scheduler> entityRepository) 
            : base(entityRepository)
        {
        }
    }
}
