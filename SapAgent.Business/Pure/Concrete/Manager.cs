using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Abstract;

namespace SapAgent.Business.Pure.Concrete
{
    public abstract class Manager<T> : IManager<T> where T : class, IEntity, new()
    {
        private readonly IBaseDal<T> _entityRepository;
        private readonly IHttpClientHelper<T> _httpClient;

        public Manager(IBaseDal<T> entityRepository, IHttpClientHelper<T> httpClient, int funcid)
        {
            _entityRepository = entityRepository;
            _httpClient = httpClient;
            FunctionId = funcid;
        }


        public int FunctionId { get; set; }

        public virtual void Add(T entity)
        {
            _entityRepository.Add(entity);
        }

        public virtual async Task<T[]> Get(string action)
        {
            var data = await _httpClient.GetMultipleItemsRequest(action);
            return data;
        }

        public void Update(T entity)
        {
            _entityRepository.Update(entity);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
           return  _entityRepository.GetAll(filter);
        }

        public virtual void UpFlag(Guid sRIndex)
        {
            throw new NotImplementedException();
        }
        public virtual void DownFlag()
        {
            throw new NotImplementedException();
        }
    }
}
