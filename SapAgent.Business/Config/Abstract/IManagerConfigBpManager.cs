using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Spa;
using BackgroundProcessNotify = SapAgent.Entities.Concrete.Config.BackgroundProcessNotify;

namespace SapAgent.Business.Config.Abstract
{
    public interface IManagerConfigBpManager: IManagerConfig<BackgroundProcess>
    {
        Task<List<AllNotifyCountViewDto>> GetCurrentStateOfNotify(int customerId);
        int GetBackgroundProcessTotalJobCount();
        Task<List<BpNotifyDetailView>> GetBpNotifyDetail(int customerProductId);
    }
}
