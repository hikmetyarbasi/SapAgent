using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class SysUsageNotifyCountViewDal : BaseDal<SysUsageNotifyCountView>
    {
        public SysUsageNotifyCountViewDal(IEntityRepository<SysUsageNotifyCountView> entityRepository) : base(entityRepository)
        {
        }
    }
}
