using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.API.Helper
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
        Task BackgroundProcessChart1(BackgroundProcessNotify notify);

    }
}
