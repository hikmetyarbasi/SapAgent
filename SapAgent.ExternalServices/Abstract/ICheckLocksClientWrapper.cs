using PrdCheckLocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SapAgent.ExternalServices.Abstract
{
    public interface ICheckLocksClientWrapper
    {
        Task<ZaygbcsysLocksRf[]> GetData();
    }
}
