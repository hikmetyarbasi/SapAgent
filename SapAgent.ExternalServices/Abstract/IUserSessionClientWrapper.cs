using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrdUserSession;

namespace SapAgent.ExternalServices.Abstract
{
    public interface IUserSessionClientWrapper
    {
        Task<ZaygbssysUsersessRf[]> GetData();
    }
}
