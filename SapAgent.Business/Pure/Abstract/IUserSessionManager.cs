using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Abstract
{
    public interface IUserSessionManager
    {
        void Add(UserSession dump);
        Task<UserSession[]> Get();
    }
}