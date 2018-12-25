using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Abstract
{
    public interface ISysListManager
    {
        void Add(Sm51SysList dump);
        Task<Sm51SysList[]> Get();
    }
}