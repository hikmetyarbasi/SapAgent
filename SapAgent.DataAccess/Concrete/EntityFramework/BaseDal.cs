using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Abstract;

namespace SapAgent.DataAccess.Concrete.EntityFramework
{
    public abstract class BaseDal<T> : IBaseDal<T> where T : class, IEntity, new()
    {
        private readonly IEntityRepository<T> _entityRepository;

        protected BaseDal(IEntityRepository<T> entityRepository, int funcid)
        {
            _entityRepository = entityRepository;
            FunctionId = funcid;
        }

        public int FunctionId { get; set; }

        public virtual T Add(T entity)
        {
            return _entityRepository.Add(entity);
        }

        public void Update(T entity)
        {
            _entityRepository.Update(entity);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter=null)
        {
            return _entityRepository.GetAll(filter);
        }

        public virtual void UpFlag()
        {
            throw new NotImplementedException();
        }

        public virtual void DownFlag()
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _entityRepository.Get(filter);
        }
    }
}
