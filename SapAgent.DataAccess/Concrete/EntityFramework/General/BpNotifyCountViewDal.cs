using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class BpNotifyCountViewDal : BaseDal<BpNotifyCountView>
    {

        public BpNotifyCountViewDal(IEntityRepository<BpNotifyCountView> entityRepository) : base(entityRepository)
        {
        }
    }
}
