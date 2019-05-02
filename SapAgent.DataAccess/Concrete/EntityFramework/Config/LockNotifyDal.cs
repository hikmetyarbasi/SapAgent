using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Config
{
    public class LockNotifyDal : BaseDal<LockNotify>
    {
        public LockNotifyDal(IEntityRepository<LockNotify> entityRepository) : base(entityRepository)
        {
        }
    }
}
