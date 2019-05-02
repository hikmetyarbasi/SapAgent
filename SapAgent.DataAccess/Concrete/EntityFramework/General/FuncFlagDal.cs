using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework.General;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class FuncFlagDal : BaseDal<FuncFlag>
    {
        public FuncFlagDal(IEntityRepository<FuncFlag> entityRepository) :
            base(entityRepository)
        {

        }
    }
}
