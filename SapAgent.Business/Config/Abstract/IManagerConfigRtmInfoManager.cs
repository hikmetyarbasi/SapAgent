using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Abstract
{
    public interface IManagerConfigRtmInfoManager : IManagerConfig<RtmInfo>
    {
        Task<List<RtmInfoNotifyDetailView>> GetRtmInfoNotifyDetail(int customerProductId);
    }
}
