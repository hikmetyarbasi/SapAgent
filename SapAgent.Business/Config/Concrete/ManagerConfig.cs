using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly IHttpClientHelper<T> _httpClient;
        private readonly IBaseDal<CustomerProductView> _productDal;

        public ManagerConfig(IBaseDal<T> entityRepository, IBaseDal<CustomerProductView> productDal, IHttpClientHelper<T> httpClient=null)
        {
            _dal = entityRepository;
            _productDal = productDal;
            _httpClient = httpClient;
        }
        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _dal.GetAll(filter);
        }

        public virtual void StartOperation()
        {
            throw new NotImplementedException();
        }

        public virtual List<BpNotifyView> GetCurrentStateOfNotify()
        {
            throw new NotImplementedException();
        }

        public virtual int GetBackgroundProcessTotalJobCount()
        {
            throw new NotImplementedException();
        }

        public virtual List<Product> GetProduct()
        {
            var list=_productDal.GetAll().GroupBy(x=>new{x.CustomerId,x.CustomerName,x.ProductId,x.ProductName}).Select(y=>new Product()
            {
                ProductName = y.Key.ProductName,
                Id = y.Key.ProductId
            }).ToList();
            return list;
        }
    }
}
