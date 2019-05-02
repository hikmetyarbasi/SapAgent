using System;
using System.Collections.Generic;
using System.Text;
using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class BackgroundProcessConfigDal : BaseDal<Entities.Concrete.Config.BackgroundProcess>
    {
        public BackgroundProcessConfigDal(IEntityRepository<BackgroundProcess> entityRepository)
            : base(entityRepository)
        {
        }
    }
}
