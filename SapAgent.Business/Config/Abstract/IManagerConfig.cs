using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Spa;

namespace SapAgent.Business.Config.Abstract
{
    public interface IManagerConfig<T>
    {
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter);
        void StartOperation(int productId);
        void UpFlag(Guid sRIndex);
        void DownFlag();
    }
}
