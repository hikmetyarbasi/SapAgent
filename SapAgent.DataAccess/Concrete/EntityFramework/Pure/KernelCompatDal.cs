using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Pure
{
    public class KernelCompatDal : BaseDal<Entities.Concrete.Pure.KernelCompat>
    {
        public KernelCompatDal(IEntityRepository<KernelCompat> entityRepository) : base(entityRepository)
        {
        }
    }
}
