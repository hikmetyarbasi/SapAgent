using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class BpNotifyViewDal : BaseDal<BpNotifyView>
    {

        public BpNotifyViewDal(IEntityRepository<BpNotifyView> entityRepository) : base(entityRepository, 0)
        {
        }
    }
}
