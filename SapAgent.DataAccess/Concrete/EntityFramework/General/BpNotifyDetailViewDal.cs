using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class BpNotifyDetailViewDal : BaseDal<BpNotifyDetailView>
    {
        public BpNotifyDetailViewDal(IEntityRepository<BpNotifyDetailView> entityRepository) : base(entityRepository)
        {

        }
    }
}
