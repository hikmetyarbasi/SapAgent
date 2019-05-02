using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class SysFileNotifyDetailViewDal:BaseDal<SysFileNotifyDetailView>
    {
        public SysFileNotifyDetailViewDal(IEntityRepository<SysFileNotifyDetailView> entityRepository) : base(entityRepository)
        {
        }
    }
}
