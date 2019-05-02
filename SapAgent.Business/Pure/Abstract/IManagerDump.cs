using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.Business.Pure.Abstract
{
    public interface IManagerDump : IManager<Dump>
    {
        void Upsert(Dump entity);
    }
}