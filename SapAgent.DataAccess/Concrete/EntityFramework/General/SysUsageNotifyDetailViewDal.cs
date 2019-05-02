using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class SysUsageNotifyDetailViewDal : BaseDal<SysUsageNotifyDetailView>
    {
        public SysUsageNotifyDetailViewDal(IEntityRepository<SysUsageNotifyDetailView> entityRepository) : base(entityRepository)
        {
        }
    }
}
