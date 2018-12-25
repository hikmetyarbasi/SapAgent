using System.Threading.Tasks;
using PrdCheckDumps;

namespace SapAgent.ExternalServices.Abstract
{
    public interface ICheckDumpsClientWrapper
    {
        Task<Rdumpov[]> GetData();
    }
}