using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Abstract;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Config
{
    public class SysUsageNotifyDal : BaseDal<SysUsageNotify>, IEntity
    {
        public SysUsageNotifyDal(IEntityRepository<SysUsageNotify> entityRepository) : base(entityRepository)
        {
        }
    }
}
