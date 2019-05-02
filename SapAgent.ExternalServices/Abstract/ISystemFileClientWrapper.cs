using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrdSystemFile;

namespace SapAgent.ExternalServices.Abstract
{
    public interface ISystemFileClientWrapper
    {
        Task<ZaygbssysSysfsyRf[]> GetData();
    }
}
