using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Abstract
{
    public interface IManagerConfigSysListManager : IManagerConfig<SysList>
    {
        Task<List<SysListNotifyDetailView>> GetSysListNotifyDetail(int customerProductId);
    }
}
