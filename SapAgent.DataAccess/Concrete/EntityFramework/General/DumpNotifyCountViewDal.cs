using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class DumpNotifyCountViewDal: BaseDal<DumpNotifyCountView>
    {
        public DumpNotifyCountViewDal(IEntityRepository<DumpNotifyCountView> entityRepository) : base(entityRepository)
        {
        }
    }
}
