using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Abstract
{
    public interface ISysUsageManager
    {
        void Add(SystemUsage dump);
        Task<SystemUsage[]> Get();
    }
}