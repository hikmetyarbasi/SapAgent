using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SapAgent.DataAccess.Abstract
{
    public interface IBaseDal<T>
    {
        int FunctionId { get; }
        T Add(T entity);
        T Get(Expression<Func<T, bool>> filter);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        void UpFlag();
        void DownFlag();
    }
}
