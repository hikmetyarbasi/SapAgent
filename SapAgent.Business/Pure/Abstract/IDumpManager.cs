using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Abstract
{
    public interface IDumpManager
    {
        void Add(Dump dump);
        Task<Dump[]> Get();
    }
}