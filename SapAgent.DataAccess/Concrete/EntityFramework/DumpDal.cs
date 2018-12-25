using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class DumpDal : BaseDal<Dump>
    {
        public new const int FunctionId = 1;
        public DumpDal(IEntityRepository<Dump> entityRepository)
            : base(entityRepository, FunctionId)
        {
        }
    }
}
