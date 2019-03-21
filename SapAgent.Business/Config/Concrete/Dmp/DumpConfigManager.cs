using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SapAgent.Business.Config.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.Config;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Concrete.Dmp
{
    public class DumpConfigManager: IManagerDmpManager
    {
        private const int FunctionId = 2;
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _flagDal;

        public DumpConfigManager(IBaseDal<FuncFlag> flagDal)
        {
            _flagDal = flagDal;
        }

        public Task<List<Dump>> GetAll(Expression<Func<Dump, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void StartOperation(int productId)
        {
            try
            {
                if (IsFlagUp())
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        private bool IsFlagUp()
        {
            var flag = _flagDal.Get(o => o.Func == FunctionId);
            return flag.Flag == 1;
        }
        public void UpFlag(Guid sRIndex)
        {
            throw new NotImplementedException();
        }
        public void DownFlag()
        {
            throw new NotImplementedException();
        }
    }
}
