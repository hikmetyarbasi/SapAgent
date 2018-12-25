using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class UserSessionDal : BaseDal<UserSession>
    {
        private new const int FunctionId = 1;
        public UserSessionDal(IEntityRepository<UserSession> entityRepository)
            : base(entityRepository, FunctionId)
        {
        }
    }
}
