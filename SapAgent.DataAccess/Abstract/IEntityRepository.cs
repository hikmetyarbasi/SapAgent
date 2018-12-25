using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using SapAgent.Entities.Abstract;

namespace SapAgent.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Add(T entry);
        void Update(T entry);
        T Get(Expression<Func<T, bool>> filter);
        void Delete(T entry);
    }
}
