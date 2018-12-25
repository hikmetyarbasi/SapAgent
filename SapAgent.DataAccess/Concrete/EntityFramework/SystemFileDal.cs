using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class SystemFileDal : BaseDal<SystemFile>
    {
        private new const int FunctionId = 1;
        public SystemFileDal(IEntityRepository<SystemFile> entityRepository) : 
            base(entityRepository, FunctionId)
        {
        }
    }
}
