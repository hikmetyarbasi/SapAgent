using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class FuncFlagDal : BaseDal<FuncFlag>
    {
        private new const int FunctionId = 0;
        public FuncFlagDal(IEntityRepository<FuncFlag> entityRepository) :
            base(entityRepository, FunctionId)
        {

        }
    }
}
