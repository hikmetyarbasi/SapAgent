using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class DumpNotifyDetailViewDal : BaseDal<DumpNotifyDetailView>
    {
        public DumpNotifyDetailViewDal(IEntityRepository<DumpNotifyDetailView> entityRepository) : base(entityRepository)
        {
        }
    }
}
