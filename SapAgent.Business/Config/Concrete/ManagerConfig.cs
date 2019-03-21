using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Config.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Abstract;
using SapAgent.Entities.Concrete.General;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Concrete
{
    public class ManagerConfig<T> : IManagerConfig<T> where T : class, IEntity, new()
    {
        public readonly IBaseDal<T> _dal;

        public ManagerConfig(IBaseDal<T> entityRepository)
        {
            _dal = entityRepository;
        }
        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return await _dal.GetAll(filter);
        }

        public virtual void StartOperation(int productId)
        {
            throw new NotImplementedException();
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
