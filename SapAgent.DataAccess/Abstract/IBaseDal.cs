using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SapAgent.Entities.Concrete.Pure;

namespace SapAgent.DataAccess.Abstract
{
    public interface IBaseDal<T>
    {
        T Add(T entity);
        T Get(Expression<Func<T, bool>> filter);
        void Update(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter=null);
        void ExecuteSqlQuery(string sql);
        void Upsert(T entity);
    }
}
