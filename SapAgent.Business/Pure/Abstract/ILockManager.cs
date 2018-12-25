using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Abstract
{
    public interface ILockManager
    {
        void Add(Lock dump);
        Task<Lock[]> Get();
    }
}