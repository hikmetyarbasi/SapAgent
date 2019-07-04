using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public class RtmInfoNotifyCountViewDal : BaseDal<RtmInfoNotifyCountView>
    {
        public RtmInfoNotifyCountViewDal(IEntityRepository<RtmInfoNotifyCountView> entityRepository) : base(entityRepository)
        {
        }
    }
}
