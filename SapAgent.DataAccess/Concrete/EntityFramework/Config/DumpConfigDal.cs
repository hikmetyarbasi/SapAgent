using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Config
{
    public class DumpConfigDal : BaseDal<Dump>
    {
        public DumpConfigDal(IEntityRepository<Dump> entityRepository) : base(entityRepository)
        {
        }
    }
}
