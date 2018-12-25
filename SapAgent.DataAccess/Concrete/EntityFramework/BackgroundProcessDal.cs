using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public class BackgroundProcessDal : BaseDal<Entities.Concrete.Pure.BackgroundProcess>
    {
        private new const int FunctionId = 1;
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _funcFlagManager;
        public BackgroundProcessDal(
            IEntityRepository<Entities.Concrete.Pure.BackgroundProcess> entityRepository,            
            IBaseDal<Entities.Concrete.Config.FuncFlag> funcFlagManager) :
            base(entityRepository, FunctionId)
        {
            _funcFlagManager = funcFlagManager;
        }
        public override void UpFlag()
        {
            var entity = new Entities.Concrete.Config.FuncFlag(FunctionId) { Flag = 1 };
            _funcFlagManager.Update(entity);
        }
        public override void DownFlag()
        {
            var entity = new Entities.Concrete.Config.FuncFlag(FunctionId) { Flag = 0 };
            _funcFlagManager.Update(entity);
        }
    }
}
