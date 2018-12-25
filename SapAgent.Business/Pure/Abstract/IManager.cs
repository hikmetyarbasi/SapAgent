using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SapAgent.Business.Pure.Abstract
{
    public interface IManager<T>
    {
        int FunctionId { get; }
        void Add(T entity);
        Task<T[]> Get(string action);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter);
        void UpFlag(Guid sRIndex);
        void DownFlag();
    }
}
