using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrdRtmInfo;

namespace SapAgent.ExternalServices.Abstract
{
    public interface IRtmInfoClientWrapper
    {
        Task<ZaygbcsysRtminfoRf[]> GetData();
    }
}
