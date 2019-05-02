using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class LockNotifyCountViewDal : BaseDal<LockNotifyCountView>
    {
        public LockNotifyCountViewDal(IEntityRepository<LockNotifyCountView> entityRepository) : base(entityRepository)
        {
        }
    }
}
