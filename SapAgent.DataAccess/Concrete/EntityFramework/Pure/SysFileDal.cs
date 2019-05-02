using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework.Pure
{
    public class SysFileDal :BaseDal<SysFile>
    {
        public SysFileDal(IEntityRepository<SysFile> entityRepository) : base(entityRepository)
        {
        }
    }
}
