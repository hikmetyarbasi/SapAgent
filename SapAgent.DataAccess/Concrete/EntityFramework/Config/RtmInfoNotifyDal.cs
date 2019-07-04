using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Config
{
    public class RtmInfoNotifyDal : BaseDal<RtmInfoNotify>
    {
        public RtmInfoNotifyDal(IEntityRepository<RtmInfoNotify> entityRepository) : base(entityRepository)
        {
        }
    }
}
