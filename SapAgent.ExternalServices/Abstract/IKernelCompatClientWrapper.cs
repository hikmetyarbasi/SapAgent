using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrdKernalCompat;

namespace SapAgent.ExternalServices.Abstract
{
    public interface IKernelCompatClientWrapper
    {
        Task<ZaygbcsysKernelstatRf> GetData();
    }
}
