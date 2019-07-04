using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class RtmInfoNotifyDetailViewDal : BaseDal<RtmInfoNotifyDetailView>
    {
        public RtmInfoNotifyDetailViewDal(IEntityRepository<RtmInfoNotifyDetailView> entityRepository) : base(entityRepository)
        {
        }
    }
}
