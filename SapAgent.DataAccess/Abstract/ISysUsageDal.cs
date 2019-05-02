using System.Threading.Tasks;
using SapAgent.Entities.Concrete;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Engine1.Abstract
{
    public interface ISysUsageDal
    {
        void Add(SysUsage dump);
        Task<SysUsage[]> Get();
    }
}