using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Helpers.Abstract;
using SapAgent.Business.Pure.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.DataAccess.Concrete.EntityFramework;
using SapAgent.Entities.Abstract;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.Business.Pure.Concrete
{
    public abstract class Manager<T> : IManager<T> where T : class, IEntity, new()
    {
        private readonly IBaseDal<Entities.Concrete.Config.FuncFlag> _funcFlagBaseDal;
        private readonly IBaseDal<T> _entityRepository;
        private readonly IHttpClientHelper<T> _httpClient;

        public Manager(IBaseDal<T> entityRepository,
            IHttpClientHelper<T> httpClient,
            int funcid,
            IBaseDal<FuncFlag> funcFlagBaseDal)
        {
            _entityRepository = entityRepository;
            _httpClient = httpClient;
            FunctionId = funcid;
            _funcFlagBaseDal = funcFlagBaseDal;
        }


        public int FunctionId { get; set; }

        
        public virtual void Add(T entity)
        {
            _entityRepository.Add(entity);
        }

        public void Upsert(T entity)
        {
            _entityRepository.Upsert(entity);
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
            return _entityRepository.GetAll(filter).Result;
        }

        public void UpFlag(Guid sRIndex)
        {
            try
            {
                var entity = _funcFlagBaseDal.Get(o => o.Func == FunctionId);
                entity.Flag = 1;
                entity.SReqIndex = sRIndex;
                _funcFlagBaseDal.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void DownFlag()
        {
            try
            {
                var entity = _funcFlagBaseDal.Get(o => o.Func == FunctionId);
                entity.Flag = 0;
                _funcFlagBaseDal.Update(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void ExecuteSqlQuery(string sql)
        {
            _entityRepository.ExecuteSqlQuery(sql);
        }
    }
}
