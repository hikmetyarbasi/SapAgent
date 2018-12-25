using System;
using System.Collections.Generic;
using System.Text;
using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class BackgroundProcessConfigDal : BaseDal<Entities.Concrete.Config.BackgroundProcess>
    {
        private new const int FunctionId = 1;
        public BackgroundProcessConfigDal(IEntityRepository<BackgroundProcess> entityRepository) 
            : base(entityRepository, FunctionId)
        {
        }
    }
}
