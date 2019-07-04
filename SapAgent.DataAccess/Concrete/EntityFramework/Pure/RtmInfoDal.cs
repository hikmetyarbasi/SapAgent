using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Pure
{
    public class RtmInfoDal:BaseDal<RtmInfo>
    {
        public RtmInfoDal(IEntityRepository<RtmInfo> entityRepository) : base(entityRepository)
        {
        }
    }
}
