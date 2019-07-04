using System;
using System.Collections.Generic;
using System.Text;
using SapAgent.Business.Config.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Concrete
{
    public class ConfigSchedulerManager :ConfigManager<Scheduler>, IManagerConfigScheduler
    {
        public ConfigSchedulerManager(IBaseDal<Scheduler> entityRepository, IBaseDal<FuncFlag> funcFlagBaseDal)
            : base(entityRepository, funcFlagBaseDal, 0)
        {
        }

    }
}
