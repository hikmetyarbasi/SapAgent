using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SapAgent.Business.General.Abstract;
using SapAgent.DataAccess.Abstract;
using SapAgent.Entities.Concrete.General;

namespace SapAgent.Business.General.Concrete
{
    public class GeneralCustomerProductViewManager :IManagerGeneralCustomerProduct
    {
        private readonly IBaseDal<CustomerProductView> _customerProductViewDal;

        public GeneralCustomerProductViewManager(IBaseDal<CustomerProductView> customerProductViewDal)
        {
            _customerProductViewDal = customerProductViewDal;
        }

        public Task<List<CustomerProductView>> GetAll(Expression<Func<CustomerProductView, bool>> filter)
        {
            return _customerProductViewDal.GetAll(filter);
        }

        public List<Product> GetProducts(int customerId)
        {
            return _customerProductViewDal.GetAll(y => y.CustomerId == customerId).Result
                .GroupBy(x => new { x.ProductName, x.ProductId })
                .Select(y => new Product()
                {
                    Id = y.Key.ProductId,
                    ProductName = y.Key.ProductName
                }).ToList();
        }

        public Client Get(int customerProductId)
        {
            throw new NotImplementedException();
        }
    }
}
