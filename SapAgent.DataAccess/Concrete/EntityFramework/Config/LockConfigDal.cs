using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.DataAccess.Concrete.EntityFramework.Pure;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Config
{
    public class LockConfigDal : BaseDal<Lock>
    {
        public LockConfigDal(IEntityRepository<Lock> entityRepository) : base(entityRepository)
        {

        }
    }
}
