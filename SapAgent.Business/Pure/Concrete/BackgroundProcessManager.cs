using System;
using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;

namespace SapAgent.Business.Pure.Concrete
{
    public class BackgroundProcessManager : Manager<Entities.Concrete.Pure.BackgroundProcess>
    {
        private new const int FunctionId = 1;
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _funcFlagManager;
        public BackgroundProcessManager(IBaseDal<Entities.Concrete.Pure.BackgroundProcess> entityRepository, IHttpClientHelper<Entities.Concrete.Pure.BackgroundProcess> httpClient, IBaseDal<Entities.Concrete.Config.FuncFlag> funcFlagManager) :
            base(entityRepository, httpClient, FunctionId)
        {
            _funcFlagManager = funcFlagManager;
        }
        public override void UpFlag(Guid sRIndex)
        {
            try
            {
                var entity = _funcFlagManager.Get(o => o.Func == FunctionId);
                entity.Flag = 1;
                entity.SReqIndex = sRIndex;
                _funcFlagManager.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public override void DownFlag()
        {
            try
            {
                var entity = _funcFlagManager.Get(o => o.Func == FunctionId);
                entity.Flag = 0;
                _funcFlagManager.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
