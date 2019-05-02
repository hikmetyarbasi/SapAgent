using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Abstract;

namespace SapAgent.DataAccess.Concrete.EntityFramework.General
{
    public abstract class BaseDal<T> : IBaseDal<T> where T : class, IEntity, new()
    {
        private readonly IEntityRepository<T> _entityRepository;

        protected BaseDal(IEntityRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public virtual T Add(T entity)
        {
            return _entityRepository.Add(entity);
        }

        public void Update(T entity)
        {
            _entityRepository.Update(entity);
        }

        public Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return _entityRepository.GetAll(filter);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _entityRepository.Get(filter);
        }

        public void ExecuteSqlQuery(string sql)
        {
            _entityRepository.ExecuteStoreProc(sql);
        }

        public void Upsert(T entity)
        {
            _entityRepository.Upsert(entity);
        }
    }
}
