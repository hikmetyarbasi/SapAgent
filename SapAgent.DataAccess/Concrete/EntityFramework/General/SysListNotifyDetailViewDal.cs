using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class SysListNotifyDetailViewDal : BaseDal<SysListNotifyDetailView>
    {
        public SysListNotifyDetailViewDal(IEntityRepository<SysListNotifyDetailView> entityRepository) : base(entityRepository)
        {
        }
    }
}
