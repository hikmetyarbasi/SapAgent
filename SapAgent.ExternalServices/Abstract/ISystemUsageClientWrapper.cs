using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrdSystemUsage;

namespace SapAgent.ExternalServices.Abstract
{
    public interface ISystemUsageClientWrapper
    {
        Task<ZaygbssysSysusageRf[]> GetData();
    }
}
