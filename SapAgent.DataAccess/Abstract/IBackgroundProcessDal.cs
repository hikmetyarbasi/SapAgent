using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Engine1.Abstract
{
    public interface IBackgroundProcessDal
    {
        Task<BackgroundProcess[]> Get();
        void Add(BackgroundProcess process);
    }
}